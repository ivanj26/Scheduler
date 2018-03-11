# Scheduler

Aplikasi untuk menjadwalkan jadwal kuliah dengan Algoritma DFS/BFS

Deskripsi tugas :
Pada tugas kali ini, mahasiswa diminta membuat aplikasi berbasis GUI (Graphical User
Interface) yang dapat menyusun rencana pengambilan kuliah, dengan memanfaatkan algoritma DFS
dan BFS. Penyusunan Rencana Kuliah dengan memanfaatkan DFS dan BFS diimplementasikan
dengan menggunakan pendekatan Topological Sorting. Berikut akan dijelaskan tugas yang
dikerjakan secara detail.

Aplikasi harus dapat menyusun rencana kuliah dengan pendekatan
topological sorting dan memanfaatkan DFS dan BFS untuk sortingnya. Video topological
sorting dapat dilihat pada laman Youtube berikut:
https://www.youtube.com/watch?v=yYW6lQ1ajx4&feature=youtu.be
Pendekatan DFS untuk Topological Sorting
a. Dari graf yang terbentuk, lakukan penelusuran terhadap DAG yang terbentuk pada
langkah sebelumnya. Setiap kali melakukan penelusuran, catat waktu selesai (time stamp)
penelusuran pada setiap simpul.
Untuk kasus pada Gambar 2, maka penelusuran DFS dapat dimulai dari C3 sehingga C3
dimulai pada waktu ke-1, dan waktu selesainya 10, yaitu setelah semua simpul selesai
ditelusuri. Pada Gambar 4, tiap simpul dilengkapi dengan informasi
[waktu_mulai/waktu_selesai]. Sebagai contoh, simpul C3 adalah simpul yang pertama
ditelusuri karena tidak memiliki busur yang masuk ke simpul C3. Simpul C3 selesai
ditelusuri setelah waktu ke-10, yaitu ketika semua simpul sudah selesai ditelusuri. Contoh
lain untuk simpul C5, waktu mulai ditelusurinya adalah time stamp ke 4 (setelah C3, C1,
C2). Waktu selesai C5 adalah 5, karena setelah C5 tidak ada lagi ‘anak’ dari C5 yang bisa
ditelusuri, sehingga kembali ke C2. Waktu selesai C2 adalah 6, dan kembali ke C1,
demikian seterusnya.
 2/9 3/6

 1/10 7/8
Gambar 4. Penelusuran DFS dari DAG daftar mata kuliah
b. Lakukan pengurutan waktu penyelesaian secara menurun untuk menghasilkan urutan
semua simpul yang ada pada DAG. Berdasarkan Gambar 4, maka urutan yang dihasilkan
adalah:
C3 C1 C4 C2 C5
C1
C3
C2
C4
C5
C1
C3
C2
C4
C5
Tugas II IF2211 Strategi Algoritma Halaman 3 28/02/18
c. Berdasarkan DAG yang sudah dihasilkan sebelumnya, maka busur yang menghubungkan
semua simpul di langkah (b), dan hasilnya urutan adalah sebagai berikut.
C3 C1 C4 C2 C5

Gambar 5. Hasil topological Sort untuk Kasus 5 mata kuliah pada gambar 2
Berdasarkan pada Gambar 5, maka rencana kuliah yang dihasilkan adalah sebagai berikut.
Semester I : C3
Semester II : C1
Semester III : C4
Semester IV : C2
Semester V : C5.
Pendekatan BFS untuk Topological Sorting
a. Dari graf (DAG) yang terbentuk, hitung semua derajat-masuk (in-degree) setiap simpul,
yaitu banyaknya busur yang masuk pada simpul tersebut. Pada contoh kasus di Gambar
2, maka derajat-masuk tiap simpul adalah sebagai berikut.
C1 : 1
C2 : 2
C3 : 0
C4 : 2
C5 : 2
b. Pilih sembarang simpul yang memiliki derajat-masuk 0. Pada kasus Gambar 2, pilih
simpul C3.
c. Ambil simpul tersebut, dan hilangkan simpul tersebut beserta semua busur yang keluar
dari simpul tersebut pada graf, dan kurangi derajat simpul yang berhubungan dengan
simpul tersebut dengan 1.
Setelah simpul C3 dipilih, maka derajat simpul yang lain menjadi sebagai berikut.
C1 : 0
C2 : 2
C4 : 1
C5 : 2
d. Ulangi langkah (b) dan (c) hingga semua simpul pada DAG terpilih. Untuk kasus pada
Gambar 2, setelah simpul terakhir dipilih maka urutan yang dihasilkan akan seperti pada
Gambar 5.
4. Aplikasi harus dapat menunjukkan langkah-langkah proses penentuan urutan dengan
memanfaatkan algoritma DFS dan BFS.
5. Aplikasi harus dapat menunjukkan hasil topological sort dengan memanfaatkan algoritma
DFS dan BFS seperti pada Gambar 5.
6. Aplikasi menampilkan hasil penentuan rencana kuliah, berupa semester dan kuliah apa saja
yang diambil pada setiap semester. Tampilan untuk fitur ini bebas, silakan dibuat sebagus
mungkin dengan berbasis GUI.
7. Data Uji akan diberikan oleh asisten. 
