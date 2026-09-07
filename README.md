Principios SOLID en ViajesYA

Single Responsibility (SRP)
- **VueloRepository**: Acceso a datos (SELECT, INSERT, UPDATE)
- **VueloService**: Validaciones y lógica de negocio
- **VueloController**: Mapeo de rutas HTTP

Cada clase tiene UNA responsabilidad.

Open/Closed (OCP)
- Usamos interfaces (IVueloRepository, IVueloService)
- Podemos agregar nuevas implementaciones sin modificar código existente

Liskov Substitution (LSP)
- VueloService implementa IVueloService
- Cualquier servicio que implemente la interfaz puede reemplazarlo

Interface Segregation (ISP)
- IVueloRepository solo tiene métodos de Vuelo
- IHotelRepository solo tiene métodos de Hotel
- No hay métodos innecesarios

Dependency Inversion (DIP)
- Controllers dependen de IVueloService (interfaz), no de VueloService (implementación)
- Services dependen de IVueloRepository (interfaz), no de VueloRepository
- Inyección de dependencias en Program.cs
