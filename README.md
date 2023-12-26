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
	  
## Usage

### Kişi Ekleme (ContactController)(Post)(ReturnValue : bool)
  -api/add-new-person endpointinden yeni kişi ekleyebilirsiniz. Örnek JSON
  
	  {
	    "name": "Ömer",
	    "surName": "Atila",
	    "corparete": "Rise Technology" 
	  }
	  
### Kişi Silme (ContactController)(Post)(ReturnValue : bool)
  -api/delete-person endpointinden var olan kişiyi silebilirsiniz. Örnek JSON
  
	  {
	    "id": 1 
	  }
	  
### Kişiye Contact Bilgisi Ekleme (ContactController)(Post)(ReturnValue : bool)
  -api/add-contact-info endpointinden yeni kullanıcı ekleyebilirsiniz. Örnek JSON
  
	  {
	    "idPerson": 1, //Kullanıcı id
	    "contactType": 1, //Phone=1,Mail=2,Location=3
        "content": "02161234567"      
      }