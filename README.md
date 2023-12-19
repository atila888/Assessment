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
  
-Başlarken:
  
  -Eğer Docker Compose ile container üzerinde çalıştırılacaksa herhangi bir configürasyona gerek yok
  
  -Eğer Local olarak çalıştırılacaksa: 
	  Öncelikle app.settings dosyaları içerisinde bulunan DB configuration ve RabbitMQ configuration ayarları yapılması gerekmektedir.
	  
	  Sonrasında Code first işlemleri için gerekli komutlar ContactService.Contact.Repository.Models altında bulunan ApplicationContext içerisinde açıklama satırı olarak vardır.
