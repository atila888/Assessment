# Utilities

-RabbitMQ

-PostgreSQL

-.net7

## Getting Started

-Projede kullanılan mimariler
  
  -EventDriven
  
  -Dependency Injection
  
  -Repository Design Pattern
  
  -Entity Framework Code First 
  
-Rapor Oluşturma Mimarisi

	<p align="center">
	  <img src="./report-arc.png" alt="Rapor Oluşturma Mimarisi" width="738">
	</p>
  
-Başlarken:
  
  -Eğer Docker Compose ile container üzerinde çalıştırılacaksa herhangi bir configürasyona gerek yok.Projenin bulunduğu aşağıdaki cmd komutunun çalıştırılması yeterlidir.
	  
	  docker-compose up --build
  
  -Docker Compose dosyasında report service başlangıçta bir kaç kere restart atabilir. RabbitMQ tam ayaklanmadığı için hata verdiğinden restart atabilir.
  
  -ContactService ve ReportService çalıştıktan sonra aşağıdaki URL den erişebilirsiniz.
     
	 ContactService : http://localhost:49154/swagger/index.html
	 
	 ReportService  : http://localhost:49282/swagger/index.html
  
  -Eğer Local olarak çalıştırılacaksa:
  
	  Öncelikle app.settings dosyaları içerisinde bulunan DB configuration ve RabbitMQ configuration ayarları yapılması gerekmektedir.
	  
	  Sonrasında Code first işlemleri için gerekli komutlar ContactService.Contact.Repository.Models altında bulunan ApplicationContext içerisinde açıklama satırı olarak vardır.
	  
##Usage

###Kullanıcı Ekleme (ContactController)(Post)
  -api/add-new-person endpointinden yeni kullanıcı ekleyebilirsiniz. Örnek JSON
	{
      "name": "Ömer",
      "surName": "Atila",
      "corparete": "Rise Technology" 
    }