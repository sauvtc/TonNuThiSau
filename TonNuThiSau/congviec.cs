using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonNuThiSau
{
    public class congviec
    {
        public int MaCv {  get; set; }
        public string TenCv {  get; set; }
        public int DoUuTienCv { get; set; }
        public string MoTaCV {  get; set; }
        public string TrangThaiCV { get; set; }
        public congviec() { }//mặc định
        public congviec(int maCv, string tenCv, int doUuTienCv, string moTaCV, string trangThaiCV)
        {
            MaCv = maCv;
            TenCv = tenCv;
            DoUuTienCv = doUuTienCv;
            MoTaCV = moTaCV;
            TrangThaiCV = trangThaiCV;
        }
    }
}
