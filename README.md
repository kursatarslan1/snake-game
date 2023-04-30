# snake-game

Merhabalar, klasik bir yılan oyunu ancak puanlama sistemi biraz farklı.

Öncelikli olarak projeyi indirdiğiniz zaman size güvenli olmadığına dair bir uyarı verebilir bu projenin resx dosyası içerisinde bir dosya olduğu zaman olur genelde 
ve bu projede de bir .ico dosyası var bunu çözmek için projenin kaynak kodlarına gidip .resx dosyasına sağ tıklayıp engellemeyi kaldır diyebilirsiniz.

![snake-1](https://user-images.githubusercontent.com/79106716/235342607-4c300e12-e934-4c49-8ffe-315508c1e42e.png)


Oyunu bir okul projesi olarak yaptım, o yüzden birkaç değişikliği var tabii. Oyuna başlamak için öncelikle isim giriliyor ve kaydet deniliyor. Daha sonrasında seviye
seçiliyor ve "B" tuşuna basarak oyun başlatılıyor. Oyun içerisinde "D" tuşunu kullanarak durdurabilir ve devam ettirebilirsiniz.

![snake2](https://user-images.githubusercontent.com/79106716/235342697-aef21859-e193-4dc1-807e-fd504410e071.png)

Yön tuşları yerine WASD tuşları ile kontrol ediliyor isteyenler kaynak kodları içerisinden değiştirebilirler. Oyunun genel görüntüsü aşağıdaki gibidir.

![snake-3](https://user-images.githubusercontent.com/79106716/235342724-493c0b51-fdf0-4dfb-827e-6192f65849d6.png)


## Puanlama sistemi

İki yem yeme arasında geçen süreyi toplam süreden çıkardığımızda eğer çıkan sonuç 100 - den az ise yani iki yem yeme arasında 100 saniyeden fazla zaman yoksa: 
 - Yem yediğimiz zaman alacağımız puan 100 /  (toplam zaman + salise/(100 - iki yem arasında geçen zaman))
 - Eğer yemler 4 köşe noktalarından birine denk geldiyse ve alındıysa ekstra 10 puan daha ekleniyor.

100 den fazla ise geçen zaman:
 - Puan alamazsınız.
