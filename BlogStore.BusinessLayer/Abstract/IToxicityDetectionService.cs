using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.BusinessLayer.Abstract
{
    public interface IToxicityDetectionService
    {
        Task<ToxicityDetectionResult> DetectToxicityAsync(string commentText);
    }
    public class ToxicityDetectionResult
    {
        public bool IsToxic { get; set; } // Sonuç: toksik mi?
        public double Score { get; set; }  // Modelin güven skoru (0..1)
        public string DetectedLabel { get; set; } // Hangi etiket (örn: "toxic")

    }
}
