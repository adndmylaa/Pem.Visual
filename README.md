## 🧠 **MathRush - Game Matematika Sederhana**

**MathRush** adalah game edukatif berbasis desktop (Windows Forms - C#) yang menguji kecepatan dan ketepatan pemain dalam menjawab soal matematika dasar (penjumlahan).

---

### 📌 **Struktur Tampilan Aplikasi**

- 🔢 **Soal Matematika** → Ditampilkan secara acak (angka 1–10).
- ⏱️ **Timer 10 Detik** → Menghitung mundur tiap soal.
- 📝 **Input Jawaban** → Kolom teks + tombol Submit.
- ⭐ **Skor Pemain** → Bertambah jika jawaban benar.
- 🗂️ **Form Kelola Data** → Menyimpan dan mengedit skor pemain (CRUD).

---

### 🧩 **Fungsi Utama & Alur Game**

#### 🔄 **ALUR PERMAINAN:**
1. **Klik tombol Mulai** → Soal pertama muncul dan timer dimulai.
2. **Pemain menjawab soal**:
   - Jika jawaban **benar**:
     - Skor bertambah.
     - Timer di-reset ke 10 detik.
     - Soal baru ditampilkan.
   - Jika jawaban **salah**:
     - Timer tetap berjalan.
3. **Jika waktu habis**:
   - Game berhenti.
   - Skor akhir disimpan dan ditampilkan.

---

### 🧾 **Data yang Disimpan ke Database (SQLite)**

| 🗂️ Nama Data         | 📄 Deskripsi                                        |
|----------------------|-----------------------------------------------------|
| `name`               | Nama pengguna                                       |
| `score`              | Skor akhir saat permainan                           |

Data ini digunakan untuk:
- Menampilkan **leaderboard**.
- Mengelola data pengguna melalui form **CRUD**.

---

### ⚙️ **Detail Teknis (C# WinForms)**

- Soal dihasilkan acak melalui `Random`.
- Timer menggunakan `System.Timers.Timer`.
- Event handler seperti `btnStart_Click`, `btnSubmit_Click`, dan `OnTimedEvent` digunakan untuk mengontrol jalannya permainan.
- Data disimpan ke database lokal SQLite melalui class `DatabaseHelper.cs`.
- Form CRUD terpisah (`FormCRUD.cs`) untuk melihat, menambah, mengedit, dan menghapus data skor.

---

### 🎨 **Desain UI**
UI dibuat menggunakan komponen standar **Windows Forms**, terdiri dari:
- Label (untuk soal dan skor),
- TextBox (untuk jawaban),
- Button (Mulai, Submit, Kelola Data),
- Timer untuk hitung mundur,
- ListBox untuk menampilkan leaderboard.

---

### 🎨 **Analisis Desain Figma**
(Link Figma: https://www.figma.com/design/88kNkf1OP7Rq2e5fz3ttJF/MathRush?node-id=0-1)
