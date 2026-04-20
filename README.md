# TUGAS-TM-PAA

---

# Book Management API

### 📝 Deskripsi Project
**Book Management API** adalah solusi backend berbasis REST API untuk mengelola inventaris buku, penulis, dan kategori. Project ini dikembangkan sebagai bagian dari tugas **LKM 1 Matakuliah Pemrograman Antarmuka Aplikasi (PAA)**. 

Domain ini dipilih untuk mendemonstrasikan implementasi relasi database yang kompleks, penggunaan *soft delete*, serta penerapan keamanan melalui *parameterized queries*.

### 🛠️ Teknologi yang Digunakan
* **Bahasa Pemrograman:** C# (.NET 8/9)
* **Framework:** ASP.NET Core Web API
* **Database:** PostgreSQL 16
* **Library (Micro-ORM):** Dapper & Npgsql (untuk performa tinggi dan keamanan akses database)
* **Dokumentasi:** Swagger UI

### 📂 Struktur Folder
```text
📁 Tugas_PAA/
├── 📁 Controllers/    # Logika endpoint API (CRUD)
├── 📁 Models/         # Data Transfer Objects (DTO) & Response Template
├── 📄 database.sql    # Script DDL (Table) & DML (Sample Data)
├── 📄 README.md       # Panduan project
├── 📄 .gitignore      # Pengecualian file sampah (.vs, bin, obj)
└── 📄 Program.cs      # Konfigurasi aplikasi
```

### 🚀 Langkah Instalasi & Cara Menjalankan

#### 1. Persiapan Database
1.  Buka **pgAdmin 4** atau tool PostgreSQL lainnya.
2.  Buat database baru bernama `book_management_db`.
3.  Buka Query Tool, salin isi dari file `database.sql`, lalu jalankan (**Execute**) untuk membuat tabel dan memasukkan data sampel.

#### 2. Konfigurasi Koneksi
1.  Buka project di **Visual Studio 2026**.
2.  Cari variabel `_connStr` di dalam `BooksController.cs`.
3.  Sesuaikan `Username` dan `Password` sesuai konfigurasi PostgreSQL di komputer Anda.

#### 3. Menjalankan Project
1.  Tekan tombol **F5** atau klik **Start Debugging** di Visual Studio.
2.  Browser akan otomatis terbuka dan menampilkan halaman **Swagger UI** di alamat `http://localhost:5052/swagger`.

### 📑 Daftar Endpoint API
Semua response menggunakan format JSON konsisten: `{ "status": boolean, "message": string, "data": object }`.

| Method | URL | Keterangan |
| :--- | :--- | :--- |
| **GET** | `/api/Books` | Mengambil semua daftar buku (yang belum dihapus) |
| **GET** | `/api/Books/{id}` | Mengambil detail buku berdasarkan ID |
| **POST** | `/api/Books` | Menambahkan buku baru ke database |
| **PUT** | `/api/Books/{id}` | Memperbarui informasi buku yang sudah ada |
| **DELETE** | `/api/Books/{id}` | Menghapus buku secara aman (**Soft Delete**) |

### 📹 Link Video Presentasi
Tonton demonstrasi lengkap project ini (Demo Database, Kode, dan API) pada link berikut:
👉 **[https://youtu.be/iKTYzAc3Wk8]**

