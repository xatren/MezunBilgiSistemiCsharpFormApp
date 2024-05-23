# Mezun Bilgi Sistemi

Bu proje, C# Windows Form uygulaması ve MySQL kullanarak oluşturulmuş bir Mezun Bilgi Sistemidir. Bu sistem, mezunların bilgilerini saklamak, güncellemek ve görüntülemek amacıyla geliştirilmiştir.

## İçindekiler

- [Kurulum](#kurulum)
- [Kullanım](#kullanım)
- [Dosya Açıklamaları](#dosya-açıklamaları)
- [Katkıda Bulunma](#katkıda-bulunma)


## Kurulum

1. Bu projeyi yerel makinenize klonlayın:
    ```bash
    git clone https://github.com/xatren/MezunBilgiSistemiCsharpFormApp.git
    ```

2. Gerekli bağımlılıkları yükleyin (varsa):
    ```bash
    nuget restore
    ```

3. Veritabanınızı yapılandırın ve `App.config` dosyasını uygun veritabanı bilgileriyle güncelleyin.

4. Veritabanı tablolarınızı oluşturmak için `database.sql` dosyasını kullanın:
    ```bash
    mysql -u kullanıcı_adı -p veritabanı_adı < database.sql
    ```

## Kullanım

Mezun Bilgi Sistemini çalıştırmak için:

1. Visual Studio veya uyumlu bir IDE ile projeyi açın.
2. `224Proje.sln` çözüm dosyasını yükleyin.
3. Projeyi çalıştırın (`F5` tuşuna basarak veya `Debug > Start Debugging` menüsünden).

## Dosya Açıklamaları

- **`Form1.cs`**: Ana form dosyasıdır, mezun bilgilerini görüntülemek ve yönetmek için ana arayüzü sağlar.
- **`KayitEkle.cs`**: Yeni mezun kayıtları eklemek için form içerir.
- **`MezunBilgiEkran.cs`**: Mezun bilgilerini detaylı olarak görüntüleme ve güncelleme işlemlerini sağlar.
- **`RaporAlmacs.cs`**: Rapor alma işlemlerini gerçekleştiren formdur.
- **`ogrenciGoruntule.cs`**: Öğrenci bilgilerini görüntülemek için kullanılan formdur.
- **`Program.cs`**: Uygulamanın başlangıç noktasıdır.

## Katkıda Bulunma

Katkıda bulunmak isterseniz, lütfen önce bir konu açarak ne yapmak istediğinizi anlatın. Büyük değişiklikler için, lütfen önce neyi değiştirmek istediğinizi tartışmak için bir konu açınız.

1. Fork yapın
2. Yeni bir dal (branch) oluşturun (`git checkout -b ozellik/AmazingFeature`)
3. Değişikliklerinizi commit edin (`git commit -m 'Yeni özellik ekle'`)
4. Branch'e push edin (`git push origin ozellik/AmazingFeature`)
5. Bir Pull Request açın


