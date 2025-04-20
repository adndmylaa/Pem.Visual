## 🧠 **MathRush - Game Matematika Sederhana**

**MathRush** adalah game edukatif berbasis web yang menguji kecepatan dan ketepatan dalam menjawab soal penjumlahan sederhana.

---

### 📌 **Struktur Tampilan**

- 🔢 **Soal Matematika** → Ditampilkan secara acak (angka 1–10)  
- ⏱️ **Timer 10 Detik** → Menghitung mundur tiap soal  
- 📝 **Input Jawaban** → Kolom isian + tombol submit  
- ⭐ **Skor Pemain** → Bertambah saat menjawab dengan benar  

---

### 🧩 **Fungsi Utama & Alur Game**

#### 🔄 **ALUR PERMAINAN:**
1. **Game dimulai otomatis** → Soal pertama langsung muncul.
2. **Pemain menjawab soal** → Jika benar:
   - Skor naik.
   - Timer di-reset ke 10 detik.
   - Soal baru ditampilkan.
3. **Jika salah / tidak dijawab**:
   - Timer tetap berjalan.
4. **Jika waktu habis**:
   - Muncul pesan *Game Over* beserta skor akhir.
   - Halaman reload untuk memulai ulang game.

---

### 🧾 **Data yang Bisa Disimpan dalam Database**

Jika ingin mengembangkan game ini lebih lanjut (misalnya membuat sistem login, leaderboard, atau statistik pemain), berikut beberapa **data penting** yang bisa disimpan:

| 🗂️ Nama Data         | 📄 Deskripsi                                        |
|----------------------|-----------------------------------------------------|
| `username`           | Nama pengguna atau ID pemain                        |
| `score`              | Skor akhir yang diperoleh saat bermain              |
| `start_time`         | Waktu saat permainan dimulai                        |
| `end_time`           | Waktu saat permainan berakhir                       |
| `duration`           | Total durasi permainan (bisa dihitung dari start-end) |
| `correct_answers`    | Jumlah soal yang dijawab dengan benar               |
| `total_questions`    | Total soal yang muncul selama sesi bermain          |

**Catatan:** Data di atas bisa digunakan untuk:
- Menampilkan **leaderboard**.
- Melacak **riwayat permainan pengguna**.
- Menganalisis **performa pemain dari waktu ke waktu**.

---

### ⚙️ **Cara Kerja Singkat (Teknis)**
- Soal dihasilkan secara acak menggunakan `Math.random()`.
- Jawaban dicek saat tombol **Submit** diklik.
- Timer diatur dengan `setInterval()` selama 1 detik.
- Game akan **restart otomatis** setelah game over.

### 🎨 **Analisis Desain Figma**
(Link Figma: https://www.figma.com/design/88kNkf1OP7Rq2e5fz3ttJF/MathRush?node-id=0-1)


