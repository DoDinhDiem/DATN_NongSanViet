export interface ISanPham {
    id?: number;
    loaiId?: number;
    tenSanPham?: string;
    giaBan?: number;
    khuyenMai?: number;
    moTa?: string;
    donViTinh?: string;
    trangThai?: boolean;
    anhsanphams?:
        | {
              duongDanAnh?: string;
              trangThai?: boolean;
          }[]
        | null;
}
