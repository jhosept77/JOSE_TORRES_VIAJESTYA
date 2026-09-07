# Documentación de Patrones de Diseño y Principios SOLID – VIAJESYA

**Proyecto:** VIAJESYA – Sistema de reservas de vuelos y hoteles  
**Autor:** José Torres  
**Tecnología:** .NET / C#

## Tabla de Contenidos

1. Resumen de patrones implementados
2. Patrones de diseño
3. Estructura del proyecto
4. Principios SOLID
5. Conclusión

## 1. Resumen de Patrones Implementados

| Categoría | Patrón | Ubicación | Propósito |
|---|---|---|---|
| Creacional | Factory Method | `PATRONES/FactoryMethod/` | Crear objetos según el tipo de proyecto |
| Creacional | Singleton | `PATRONES/Singleton/` | Mantener una única instancia del gestor de conexión |
| Estructural | Adapter | `PATRONES/Adapter/` | Adaptar un proveedor externo de correo |
| Comportamiento | Strategy | `PATRONES/Strategy/` | Encapsular diferentes reglas de cálculo de tarifas |

## 2. Patrones de Diseño

### 2.1 Factory Method

**Problema:** La creación de diferentes tipos de vuelos y reservas puede generar múltiples condicionales en el código.

**Solución:** Centraliza la creación de objetos mediante factories, evitando que el cliente conozca las clases concretas.

**Principales clases:**
- `IDtoFactory`: define el método de creación.
- `VueloDtoFactory`: crea vuelos nacionales o internacionales.
- `ReservaDtoFactory`: crea reservas estándar o grupales.
- `TipoProyecto`: define los tipos disponibles.

### 2.2 Singleton

**Problema:** Crear múltiples instancias del gestor de conexión a la base de datos.

**Solución:** Garantiza una única instancia del gestor de conexión.

**Principales clases:**
- `Conexion`: administra la instancia única.

### 2.3 Adapter

**Problema:** La aplicación depende directamente de la interfaz de un proveedor externo de correo.

**Solución:** El Adapter adapta el proveedor externo a una interfaz propia del sistema.

**Principales clases:**
- `IEmailService`: interfaz utilizada por la aplicación.
- `EmailAdapter`: adapta el proveedor externo.

### 2.4 Strategy

**Problema:** Diferentes reglas para calcular tarifas pueden generar numerosos condicionales.

**Solución:** Encapsula cada regla de cálculo en una estrategia independiente.

**Principales clases:**
- `ITarifaStrategy`: define el contrato para calcular tarifas.
- Estrategias concretas: implementan las diferentes reglas.
- `CalculadorTarifa`: utiliza la estrategia seleccionada.

## 3. Estructura del Proyecto

```text
VIAJESYA/
└── PATRONES/
    ├── Adapter/
    ├── FactoryMethod/
    ├── Singleton/
    └── Strategy/
```

## 4. Principios SOLID en VIAJESYA

### S — Single Responsibility
Cada clase debe tener una responsabilidad específica.

### O — Open/Closed
El sistema debe permitir agregar nuevas funcionalidades sin modificar el código existente.

### L — Liskov Substitution
Las implementaciones concretas deben poder sustituir a sus interfaces sin alterar el funcionamiento esperado.

### I — Interface Segregation
Las interfaces deben ser específicas y contener únicamente los métodos necesarios.

### D — Dependency Inversion
Las clases deben depender de abstracciones y no directamente de implementaciones concretas.

Los patrones implementados apoyan estos principios al reducir el acoplamiento y facilitar la extensión del sistema.

## 5. Conclusión

VIAJESYA utiliza Factory Method, Singleton, Adapter y Strategy para mejorar la organización y mantenibilidad del código. La aplicación de SOLID permite reducir el acoplamiento, facilitar la extensión del sistema y mantener una arquitectura más flexible.