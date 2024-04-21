export interface IHoaDonNhap {
    id?: number;
    nhanVienId?: number;
    nhaCungCapId?: number;
    trangThaiThanhToan?: boolean;
    tongTien?: number;
    tenNhanVien?: string;
    tenNhaCungCap?: string;
    createdAt?: Date;
    chitiethoadonnhaps?:
        | {
              sanPhamId?: number;
              soLuong?: number;
              giaNhap?: number;
              thanhTien?: number;
          }[]
        | null;
}
