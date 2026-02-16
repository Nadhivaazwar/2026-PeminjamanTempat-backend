# 2026-PeminjamanTempat-backend
# Peminjaman Tempat

## Deskripsi
Peminjaman Tempat adalah aplikasi untuk mengelola peminjaman ruangan di suatu tempat. Aplikasi ini memungkinkan administrator untuk melihat dan mengubah status peminjaman ruangan, mulai dari status "Menunggu Persetujuan", "Disetujui", hingga "Ditolak". Tujuan utama aplikasi ini adalah untuk mempermudah manajemen ruangan dan memastikan semua peminjaman tercatat dengan baik dan akurat.

## Fitur
- Menampilkan daftar peminjaman ruangan.
- Mengubah status peminjaman antara "Menunggu Persetujuan", "Disetujui", dan "Ditolak".
- Menghubungkan data peminjaman dengan tempat yang tersedia.
- Real-time status pembaruan antara frontend dan backend.
- API untuk memperbarui status peminjaman.

## Tech Stack
- **Frontend**: React, Axios, JavaScript, HTML, CSS
- **Backend**: ASP.NET Core, C#
- **Database**: SQL Server
- **Others**: Swagger untuk dokumentasi API, Entity Framework untuk ORM.

## Instalasi

### Backend (PeminjamanTempatBackend)
1. Clone repositori:
    ```bash
    git clone https://github.com/username/2026-PeminjamanTempat-backend.git
    ```
2. Masuk ke direktori project:
    ```bash
    cd 2026-PeminjamanTempat-backend
    ```
3. Pastikan kamu sudah menginstal **.NET Core SDK**. Jika belum, instal di [sini](https://dotnet.microsoft.com/download).
4. Restore dependensi:
    ```bash
    dotnet restore
    ```
5. Jalankan aplikasi:
    ```bash
    dotnet run
    ```
    Aplikasi backend akan berjalan di `http://localhost:5000`.

### Frontend (PeminjamanTempatFrontend)
1. Clone repositori:
    ```bash
    git clone https://github.com/username/2026-PeminjamanTempat-frontend.git
    ```
2. Masuk ke direktori project:
    ```bash
    cd 2026-PeminjamanTempat-frontend
    ```
3. Instal dependensi:
    ```bash
    npm install
    ```
4. Jalankan aplikasi:
    ```bash
    npm start
    ```
    Aplikasi frontend akan berjalan di `http://localhost:3000`.

## Penggunaan
Setelah aplikasi berjalan, kamu dapat mengakses frontend di `http://localhost:3000`. Di sana, kamu dapat melihat daftar peminjaman ruangan dan mengubah statusnya. Setiap perubahan status akan terhubung dengan backend dan memperbarui database secara otomatis.

### API untuk Mengupdate Status
Untuk mengupdate status peminjaman, frontend akan mengirimkan permintaan PUT ke API backend:
