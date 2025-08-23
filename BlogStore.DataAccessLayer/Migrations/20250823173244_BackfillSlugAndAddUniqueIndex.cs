using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogStore.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class BackfillSlugAndAddUniqueIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1) Slug kolonunu index'e uygun uzunluğa getir
            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Articles",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            // 2) Mevcut kayıtlarda Slug boşsa başlıktan üret
            migrationBuilder.Sql(@"
    -- Slug boş olanlar için kaynağı Title yap
    UPDATE A SET A.Slug = A.Title
    FROM Articles A
    WHERE (A.Slug IS NULL OR LTRIM(RTRIM(A.Slug)) = N'') AND A.Title IS NOT NULL;

    -- Türkçe karakterleri çevir
    UPDATE Articles SET Slug = REPLACE(Slug, N'Ç', 'c');
    UPDATE Articles SET Slug = REPLACE(Slug, N'Ğ', 'g');
    UPDATE Articles SET Slug = REPLACE(Slug, N'İ', 'i');
    UPDATE Articles SET Slug = REPLACE(Slug, N'Ö', 'o');
    UPDATE Articles SET Slug = REPLACE(Slug, N'Ş', 's');
    UPDATE Articles SET Slug = REPLACE(Slug, N'Ü', 'u');
    UPDATE Articles SET Slug = REPLACE(Slug, N'ç', 'c');
    UPDATE Articles SET Slug = REPLACE(Slug, N'ğ', 'g');
    UPDATE Articles SET Slug = REPLACE(Slug, N'ı', 'i');
    UPDATE Articles SET Slug = REPLACE(Slug, N'ö', 'o');
    UPDATE Articles SET Slug = REPLACE(Slug, N'ş', 's');
    UPDATE Articles SET Slug = REPLACE(Slug, N'ü', 'u');

    -- küçük harfe çevir
    UPDATE Articles SET Slug = LOWER(Slug) WHERE Slug IS NOT NULL;

    -- istenmeyen karakterleri sil
    UPDATE Articles SET Slug = REPLACE(Slug, N'&', N'');
    UPDATE Articles SET Slug = REPLACE(Slug, N'''', N'');  -- tek tırnak
    UPDATE Articles SET Slug = REPLACE(Slug, N'""', N'');  -- çift tırnak
    UPDATE Articles SET Slug = REPLACE(Slug, N'!', N'');
    UPDATE Articles SET Slug = REPLACE(Slug, N'?', N'');
    UPDATE Articles SET Slug = REPLACE(Slug, N',', N'');
    UPDATE Articles SET Slug = REPLACE(Slug, N'.', N'');
    UPDATE Articles SET Slug = REPLACE(Slug, N':', N'');
    UPDATE Articles SET Slug = REPLACE(Slug, N';', N'');
    UPDATE Articles SET Slug = REPLACE(Slug, N'/', N'');
    UPDATE Articles SET Slug = REPLACE(Slug, N'\\', N'');
    UPDATE Articles SET Slug = REPLACE(Slug, N'(', N'');
    UPDATE Articles SET Slug = REPLACE(Slug, N')', N'');
    UPDATE Articles SET Slug = REPLACE(Slug, N'[', N'');
    UPDATE Articles SET Slug = REPLACE(Slug, N']', N'');
    UPDATE Articles SET Slug = REPLACE(Slug, N'{', N'');
    UPDATE Articles SET Slug = REPLACE(Slug, N'}', N'');
    UPDATE Articles SET Slug = REPLACE(Slug, N'+', N'');
    UPDATE Articles SET Slug = REPLACE(Slug, N'=', N'');
    UPDATE Articles SET Slug = REPLACE(Slug, N'%', N'');
    UPDATE Articles SET Slug = REPLACE(Slug, N'#', N'');
    UPDATE Articles SET Slug = REPLACE(Slug, N'*', N'');
    UPDATE Articles SET Slug = REPLACE(Slug, N'@', N'');
    UPDATE Articles SET Slug = REPLACE(Slug, N'^', N'');
    UPDATE Articles SET Slug = REPLACE(Slug, N'~', N'');
    UPDATE Articles SET Slug = REPLACE(Slug, N'`', N'');
    UPDATE Articles SET Slug = REPLACE(Slug, N'<', N'');
    UPDATE Articles SET Slug = REPLACE(Slug, N'>', N'');
    UPDATE Articles SET Slug = REPLACE(Slug, N'|', N'');

    -- çift boşlukları erit
    WHILE EXISTS (SELECT 1 FROM Articles WHERE Slug LIKE N'%  %')
        UPDATE Articles SET Slug = REPLACE(Slug, N'  ', N' ');

    -- boşluğu '-' yap
    UPDATE Articles SET Slug = REPLACE(Slug, N' ', N'-') WHERE Slug LIKE N'% %';

    -- birden fazla '-' tek olsun
    WHILE EXISTS (SELECT 1 FROM Articles WHERE Slug LIKE N'%--%')
        UPDATE Articles SET Slug = REPLACE(Slug, N'--', N'-');

    -- baş/son '-' temizle
    UPDATE Articles SET Slug = CASE WHEN LEFT(Slug,1)='-' THEN SUBSTRING(Slug,2,LEN(Slug)-1) ELSE Slug END;
    UPDATE Articles SET Slug = CASE WHEN RIGHT(Slug,1)='-' THEN SUBSTRING(Slug,1,LEN(Slug)-1) ELSE Slug END;

    -- hala boşsa fallback
    UPDATE Articles
    SET Slug = CONCAT('makale-', ArticleId)
    WHERE Slug IS NULL OR LTRIM(RTRIM(Slug)) = N'';
");


            // 3) Çakışan slug'ları tekilleştir (-2, -3...)
            migrationBuilder.Sql(@"
                ;WITH D AS (
                  SELECT ArticleId, Slug,
                         ROW_NUMBER() OVER (PARTITION BY Slug ORDER BY ArticleId) AS rn
                  FROM Articles
                )
                UPDATE A
                SET Slug = CONCAT(A.Slug, '-', D.rn)
                FROM Articles A
                INNER JOIN D ON D.ArticleId = A.ArticleId
                WHERE D.rn > 1;
            ");

            // 4) NOT NULL yap
            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Articles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            // 5) Unique index ekle
            migrationBuilder.CreateIndex(
                name: "IX_Articles_Slug",
                table: "Articles",
                column: "Slug",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Articles_Slug",
                table: "Articles");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
