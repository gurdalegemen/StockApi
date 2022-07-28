# StockApi
Sistemden ürünlerin giriş ve çıkışlarının yapılabileceği küçük bir stok kontrol uygulamasıdır.

# Veritabanı kayıtları (PostgreSQL)
![image](https://user-images.githubusercontent.com/82399866/181449879-49061c91-0ad5-406b-a0ce-8afe833cf6f2.png)

Veritabanında fotoğrafta da görüldüğü üzere silik durumda olan 2(iki) ve aktif durumda olan 2(iki) kayıtla beraber 4(dört) kayıt bulunmaktadır.

# Api

## GetAll
![image](https://user-images.githubusercontent.com/82399866/181451202-0d63532e-7ef9-4cf5-94e1-67a4e1d879b8.png)
Fotoğrafta da görüldüğü üzere veritabanında IsDeleted sütunu false olan tüm kayıtları getiren istek.

## GetById
![image](https://user-images.githubusercontent.com/82399866/181451861-7f43b48a-ab63-4bb7-92fc-460f6f5ddfc0.png)
Bellirli bir id ile veritabanından kayıt getiren istek. Aradığı kayıtın olmaması ya da silinmiş olma durumuna karşı hata belirtir.
![image](https://user-images.githubusercontent.com/82399866/181452186-08c34cd6-3f95-4fbb-af83-3402c50ca7ac.png)

## Insert
![image](https://user-images.githubusercontent.com/82399866/181452400-f8eaa138-4d52-433b-919e-d4a1c114f411.png)
Verilen ürün bilgileri ile veritabanına yazma işlemini gerçekleştiren istek. Veritabanında gözüken ProductId, CreatedAt ve IsDeleted sütunları kayıt esnasında otomatik oluştukları için giriş sırasında bu bilgilere ihtiyaç duyulmamıştır.

Ekleme işleninden sonra veritabanının yeni görüntüsü:
![image](https://user-images.githubusercontent.com/82399866/181452841-60f21c46-1e3b-4813-bae5-fff9423525ff.png)

## Delete
![image](https://user-images.githubusercontent.com/82399866/181452967-e0038baf-9927-4a2e-9aff-9ed3ee18ba0f.png)
Son eklediğimiz id numarası 12 olan kayıtı silme işlemini gerçekleştiren istek. Silme işleminde veri kaybı yaşanmaması adına soft delete kullanıldı. Veritabanı üzerinde ürünün IsDeleted sütunu true durumuna çekilerek işlem gerçekleştirildi. Böylece GetAll ve GetById istekleri sırasında dönen cevapta gözükmemesi sağlanmış oldu.

Silme işleminden sonra veritabanında kayıtın görüntüsü:
![image](https://user-images.githubusercontent.com/82399866/181453596-3c4e96d1-45dc-47ed-a397-966297f88430.png)

## Update
![image](https://user-images.githubusercontent.com/82399866/181454183-88dfdc9f-0e86-4efe-b9f4-e6c3ea1573f6.png)
Verilen id üzerinde Ürün Adı, Fiyatı ve Stok Sayısı güncellemesi yapan güncelleme isteği. Ürünün olmaması veya silinmiş olması durumunda güncelleme yapmaz.

Güncelleme yapılmadan önce ve sonraki veritabanı kayıtları.
![image](https://user-images.githubusercontent.com/82399866/181453899-19731eaf-4bc1-4bd0-888b-af979853866d.png)
![image](https://user-images.githubusercontent.com/82399866/181454136-0320e5bc-d586-4291-a8da-1647e24c6c9e.png)



