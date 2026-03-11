# Sistem Peminjaman Tempat 2026

Aplikasi manajemen peminjaman ruangan terintegrasi yang dibangun untuk memenuhi tugas pengembangan perangkat lunak v1.0.0.

## 🛠 Teknologi yang Digunakan

### **Backend**
* **Framework**: .NET 10.0 (ASP.NET Core Web API)
* **Runtime Version**: 10.0.102
* **ORM**: Entity Framework Core 10.0.0
* **Database**: SQLite
* **API Documentation**: Swagger / Swashbuckle 10.1.3 & Scalar

### **Frontend**
* **Library Utama**: React v19.2.4
* **Routing**: React Router Dom v6.30.3
* **Styling**: Bootstrap v5.3.8 & React Icons
* **Build Tool**: React Scripts v5.0.1

## 🚀 Fitur Utama
* **Manajemen Ruangan**: CRUD lengkap (Create, Read, Update, Delete) data tempat/ruangan.
* **Manajemen Peminjaman**: Pengajuan jadwal peminjaman tempat secara real-time.
* **Verifikasi Status**: Sistem persetujuan peminjaman (Pending, Disetujui, Ditolak).
* **Riwayat Akses**: Pencatatan log akses penggunaan ruangan.

## 📋 Cara Menjalankan Proyek

### **Prasyarat**
* .NET 10 SDK installed
* Node.js & npm installed

### **Langkah Instalasi**

1. **Persiapan Database (Backend)**:
   ```bash
   cd 2026-PeminjamanTempat-backend
   dotnet restore
   dotnet ef database update
   dotnet run

2. **Persiapan**