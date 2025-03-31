# Roguelike Adventure Game

## 📖 Tentang Game
Roguelike Adventure Game adalah permainan berbasis **Python** dan **Pygame** yang mengusung konsep dungeon-crawler. Pemain akan menjelajahi ruangan-ruangan misterius, menghadapi berbagai musuh, mengumpulkan item, dan bertahan hidup dalam petualangan yang menantang.

Game ini terdiri dari beberapa fungsi utama yang bekerja sama untuk menciptakan pengalaman bermain yang dinamis dan seru.

---

## 🛠️ Fitur Utama

### ⚔️ Sistem Pertarungan
**File:** `roguey/classes/combat.py`
- Pemain dapat bertarung dengan musuh menggunakan mekanisme berbasis serangan dan pertahanan.
- Setiap serangan akan dihitung berdasarkan atribut karakter.
- Menentukan kemenangan atau kekalahan dalam pertempuran.

🧪 **Pengujian:**  
```bash
py.test tests.py -k combat_system
```

---

### 🗺️ Sistem Pemetaan dan Navigasi
**File:** `roguey/classes/map.py`
- Ruang bawah tanah (dungeon) dibuat dengan sistem grid.
- Pemain dapat berpindah dari satu ruangan ke ruangan lain.
- Beberapa ruangan mungkin memiliki jebakan, musuh, atau harta karun.

🧪 **Pengujian:**  
```bash
py.test tests.py -k map_navigation
```

---

### 🎒 Manajemen Inventaris
**File:** `roguey/classes/inventory.py`
- Pemain dapat mengumpulkan dan menggunakan berbagai item.
- Item seperti senjata atau potion dapat meningkatkan kemampuan karakter.
- Inventaris memiliki kapasitas terbatas sehingga strategi pemilihan item diperlukan.

🧪 **Pengujian:**  
```bash
py.test tests.py -k inventory_management
```

---

### 👹 Sistem Musuh & AI
**File:** `roguey/classes/enemy.py`
- Musuh memiliki atribut unik seperti kekuatan serangan dan pertahanan.
- AI musuh menentukan pola serangan dan strategi dalam pertarungan.
- Beberapa musuh lebih agresif dan sulit dikalahkan dibandingkan yang lain.

🧪 **Pengujian:**  
```bash
py.test tests.py -k enemy_ai
```

---

### 🏆 Mekanisme Kemenangan dan Kekalahan
**File:** `roguey/classes/game.py`
- Pemain menang setelah menyelesaikan misi atau mengalahkan bos terakhir.
- Jika nyawa pemain habis, permainan akan berakhir.
- Opsi untuk memulai kembali setelah kalah tersedia.

🧪 **Pengujian:**  
```bash
py.test tests.py -k game_outcome
```

---

## 🚀 Cara Menjalankan Game
Pastikan Anda telah menginstal **Python** dan **Pygame** sebelum menjalankan game ini.

1. **Clone repositori**
```bash
git clone <repo-url>
cd roguelike-adventure-game
```

2. **Instal dependensi**
```bash
pip install -r requirements.txt
```

3. **Jalankan game**
```bash
python main.py
```

---
