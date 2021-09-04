

* Bir iş katmanına birim test yazma.
	* İş katmanlarına birim test yazma noktasında en büyük problem birim testin bir noktada
	integrated test'e dönüşmesidir. Bunun en büyük nedeni nesnel bir proje geliştirmesi
	yapılmamasıdır. Bir nesneye bağımlı kalan iş katmanı için birim test yazmak imkansıza
	yakındır. Bunun önüne SOLID ile geçebiliriz.

	* Bu proje bazında nesnellik ön planda olduğu için "Dependensy Injection" sayesinde 
	birim testlerimizi güvenle yazabiliriz.

	* CoinManager için yazdığımız ilk örnek;
		* Gereksinim -> Bir coin birden fazla eklenemez.
	* Bu gereksinimin karşılanması için ilk önce bağımlılık problemi çözülmelidir. 
	CoinManager sınıfından bir nesne oluşturulmak istendiğinde bağımlılık konusundaki ilk
	engelimiz CoinManager'ın "DataAccess" katmanından başka bir sınıf istemesidir. Bu eğitim
	kapsamında bunun için projeye "MOQ v4.5.20" framework'ü eklenmiştir.

	* MOQ ile çalışmak;
		* Moq sayesinde ICoinDal sınıfına ait sahte bir sınıf oluşturduk.
		* Sahte sınıfa kullanılacak metotların alarmları kurulur.
