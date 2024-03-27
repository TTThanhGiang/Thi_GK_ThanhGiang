using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thi_GK_ThanhGiang
{
    class Nguoi
    {
        public Nguoi()
        {
        }

        public string hoTen { get; set; }
        public int tuoi { get; set; }
        public string ngheNghiep { get; set; }
        public string cmnd { get; set; }
        public int hoGiaDinh { get; set; }

        public Nguoi(string hoTen, int tuoi, string ngheNghiep, string cmnd, int hoGiaDinh)
        {
            this.hoTen = hoTen;
            this.tuoi = tuoi;
            this.ngheNghiep = ngheNghiep;
            this.cmnd = cmnd;
            this.hoGiaDinh = hoGiaDinh;
        }
    }
}
