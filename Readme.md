# Ejercicio técnico de administración de inventario

## Índice

- [Ejercicio técnico de administración de inventario](#ejercicio-técnico-de-administración-de-inventario)
  - [Índice](#índice)
  - [Instrucciones para correr la aplicación](#instrucciones-para-correr-la-aplicación)
    - [Requisitos](#requisitos)
    - [Ejecutar la aplicación](#ejecutar-la-aplicación)
  - [Breve descripción y elementos asumidos](#breve-descripción-y-elementos-asumidos)
    - [Patrones y principios](#patrones-y-principios)
  - [Paquetes NuGet](#paquetes-nuget)

## Instrucciones para correr la aplicación

### Requisitos
- Para ejecutar la aplicación es necesario .NET 6

### Ejecutar la aplicación

- La aplicación puede ser ejecutada desde un VS o por un terminal
- Tiene integrada una autenticación básica pero solo en el controlador ItemEventController, para permitir el testeo de ItemController sin necesidad de autenticarse
  - Para autenticarse se crean dos usuarios estáticos
    - Usuario 1
      - user: user1
      - password: password1
    - Usuario 2
      - user: user2
      - password: password2

## Breve descripción y elementos asumidos

- Se utiliza DDD para modelar la solución y se crean las capas 
  - Application (InventoryManager.Application)
  - Domain (InventoryManager.Domain)
  - Infrastructure
    - para este último se crearon dos proyectos para separar la persistencia (InventoryManager.Persistence) de los demás servicios de infraestructura (InventoryManager.Infrastructure)

- Se utiliza una base datos en memoria para lo cual se utilizó el paquete de NuGet <strong>"Microsoft.EntityFrameworkCore.InMemory"</strong>

- Para el requerimiento de lanzar eventos, como se está utilizando una base de datos en memoria se asume que estos serán un registro dentro de la base de datos. Sin embargo, se utiliza el patrón mediator para evitar la dependencia con las entidades o funciones del dominio Item. De esta forma en caso de ser necesario se puede implementar un nuevo handler, que implemente el envío del evento a otra fuente de datos o servicios, para responder a la misma solicitud.

### Patrones y principios

- SOLID
        
    Se utilizaron los principios básicos SOLID en todas las capas y clases creadas, para mejor comprensión y facilitar el mantenimiento.

- CQRS

    El uso de este patrón aporta flexibilidad y escalabilidad al sistema, manteniendo una separación entre los comandos y las queries
    - Por cada entidad de dominio se creó una estructura común:
      - Requests
        - Queries
        - Commands
      - Handlers
        - Queries
        - Commands

- Mediator

    Este patrón aporta independencia entre los componentes al utilizar un mediador para ejecutar solicitudes en lugar de crear dependencias directas entre los componentes. Se utilizó el paquete de NuGet <strong>"MediatR.Extensions.Microsoft.DependencyInjection"</strong>

- Repository
  
    Permite encapsular los comportamientos y funciones relacionadas con el acceso a datos. Además, al vincularlo con el principio de segregación de interfaces y la inversión de dependencia, permite abstraer las dependencias de la implementación.

- MVC

    Se utiliza el patrón MVC para lograr la separación de intereses en la exposición de la API. Al mismo tiempo se utilizan los DTO para lograr que para cada funcionalidad se solicite y se expongan sólo los datos necesarios

## Paquetes NuGet

- Microsoft.EntityFrameworkCore.SqlServer
      
    Utilizado para el acceso a la información en la fuente de datos.

- Microsoft.EntityFrameworkCore.InMemory

    Es utilizada para abstraer la capa de persistencia a una base de datos en memoria.

- Microsoft.Extensions.Logging.Abstractions

    Paquete de abstracción para el uso de ILogger. Fue utilizado en el servicio <strong>ProcessingItemExpiredHostedService</strong> para visualizar su correcto funcionamiento a través de la consola.

- AutoMapper.Extensions.Microsoft.DependencyInjection

    Posibilita el mapeo entre dos objetos, muy empleado en la transformación de la información de objetos de dominio a DTOs.

- MediatR.Extensions.Microsoft.DependencyInjection

    Es utilizada para aplicar el patrón de diseño Mediator junto a la inyección de dependencia de .NET 6.

- FluentValidation.DependencyInjectionExtensions

    Es utilizada para crear las reglas de validación de datos para los objetos DTO, empleados para recibir información. Brinda una forma cómoda de validar las propiedades de los objetos.

- Moq

    Utilizado en las pruebas unitarias para la creación de objetos mocks.

- Shouldly

    Librería que facilita la creación de los Asserts en las pruebas unitarias.
