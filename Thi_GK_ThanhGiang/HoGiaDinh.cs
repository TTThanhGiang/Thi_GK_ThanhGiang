using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thi_GK_ThanhGiang
{
    class HoGiaDinh
    {
        public HoGiaDinh()
        {
        }

        public int hoGiaDinh { get; set; }
        public int soThanhVien { get; set; }
        public int soConTrai { get; set; }
        public int soConGai { get; set; }
        public string soNha { get; set; }
        public int khuPho { get; set; }

        public HoGiaDinh(int hoGiaDinh, int soThanhVien, int soConTrai, int soConGai, string soNha, int khuPho)
        {
            this.hoGiaDinh = hoGiaDinh;
            this.soThanhVien = soThanhVien;
            this.soConTrai = soConTrai;
            this.soConGai = soConGai;
            this.soNha = soNha;
            this.khuPho = khuPho;
        }
    }
}
