using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thi_GK_ThanhGiang
{
    class KhuPho
    {
        public int khuPho { get; set; }
        public string tenKhuPho { get; set; }

        public KhuPho(int khuPho, string tenKhuPho)
        {
            this.khuPho = khuPho;
            this.tenKhuPho = tenKhuPho;
        }

        public KhuPho()
        {
        }
    }
}
