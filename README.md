# MechanicalWorkShopWebApi

## 🏗️ Arquitectura del Proyecto

Este proyecto implementa una **API RESTful** para la gestión de un taller mecánico, siguiendo los principios de **Clean Architecture** y **Domain-Driven Design (DDD)**. La solución está organizada en capas bien definidas que promueven la separación de responsabilidades, escalabilidad y mantenibilidad del código.

### 📐 Patrón Arquitectónico

El proyecto utiliza una arquitectura en capas basada en los siguientes principios:

- **Separación de responsabilidades**: Cada capa tiene una responsabilidad específica y bien definida
- **Inversión de dependencias**: Las capas superiores no dependen de las inferiores directamente, sino de abstracciones (interfaces)
- **Independencia de frameworks**: La lógica de negocio no depende de tecnologías específicas
- **Testabilidad**: La arquitectura facilita las pruebas unitarias y de integración

### 🔷 Estructura de Capas

```
┌─────────────────────────────────────────┐
│     MechanicalWorkShopWebApi.Api        │  ← Capa de Presentación
│         (ASP.NET Core Web API)          │
└─────────────────────────────────────────┘
                    ↓
┌─────────────────────────────────────────┐
│   MechanicalWorkShopWebApi.Services     │  ← Capa de Aplicación
│       (Lógica de Negocio)               │
└─────────────────────────────────────────┘
                    ↓
┌─────────────────────────────────────────┐
│    MechanicalWorkShopWebApi.Domain      │  ← Capa de Dominio
│    (Entidades, DTOs, Interfaces)        │
└─────────────────────────────────────────┘
                    ↓
┌─────────────────────────────────────────┐
│ MechanicalWorkShopWebApi.Infrastructure │  ← Capa de Infraestructura
│   (Entity Framework, Repositorios)      │
└─────────────────────────────────────────┘
                    ↓
              [SQL Server]
```

---

## 📦 Descripción de Capas

### 1️⃣ **MechanicalWorkShopWebApi.Api** (Capa de Presentación)

**Responsabilidad**: Punto de entrada de la aplicación. Maneja las peticiones HTTP y devuelve respuestas JSON.

**Componentes principales**:
- **Controllers**: Exponen los endpoints de la API (ej: `UserController`)
- **Program.cs**: Configuración de servicios, middleware y dependency injection
- **Extensions**: Métodos de extensión para configuraciones personalizadas

**Tecnologías**:
- ASP.NET Core 9.0
- Swagger/OpenAPI (documentación de API)
- AutoMapper (mapeo de objetos)

**Dependencias**:
```
Api → Services → Domain → Infrastructure
```

---

### 2️⃣ **MechanicalWorkShopWebApi.Services** (Capa de Aplicación)

**Responsabilidad**: Contiene la lógica de negocio y orquesta las operaciones entre la capa de presentación y la capa de dominio.

**Componentes principales**:
- **Implementations**: Implementaciones concretas de los servicios (ej: `UserService`)
- **Mappings**: Perfiles de AutoMapper para convertir entre entidades y DTOs

**Características**:
- Implementa las interfaces definidas en `Domain/Interfaces/IService`
- Coordina las llamadas a los repositorios
- Aplica reglas de negocio complejas
- Transforma datos entre DTOs y entidades

**Tecnologías**:
- AutoMapper 12.0.1

**Dependencias**:
```
Services → Domain
```

---

### 3️⃣ **MechanicalWorkShopWebApi.Domain** (Capa de Dominio)

**Responsabilidad**: Núcleo de la aplicación. Define las entidades del negocio, contratos (interfaces) y objetos de transferencia de datos (DTOs).

**Componentes principales**:

#### 📂 **Models** (Entidades del Dominio):
- `User`: Usuarios del sistema
- `Vehicle`: Vehículos de los clientes
- `Diagnostic`: Diagnósticos de vehículos
- `Estimate`: Estimaciones de trabajo (presupuestos)
- `EstimatePart`: Partes/repuestos del estimado
- `EstimateLabor`: Mano de obra del estimado
- `EstimateFlatFee`: Tarifas fijas del estimado
- `Invoice`: Facturas
- `Payment`: Pagos realizados
- `AccountReceivable`: Cuentas por cobrar
- `Note`: Notas y comentarios
- `Reports`: Reportes del sistema
- `SalesReport`: Reportes de ventas
- `SalesReportDetail`: Detalles de reportes de ventas
- `TechnicianDiagnostic`: Diagnósticos por técnico
- `UserWorkshop`: Relación usuario-taller
- `WorkshopSettings`: Configuración del taller
- `LaborTaxMarkupSettings`: Configuración de impuestos y márgenes

#### 📂 **DTOs** (Data Transfer Objects):
- `UserDto`: DTO para transferencia de datos de usuario

#### 📂 **Interfaces**:
- **IRepository**: Contratos para acceso a datos
  - `IUserRepository`: Operaciones de usuario en base de datos
- **IService**: Contratos para servicios de negocio
  - `IUserService`: Operaciones de lógica de negocio de usuarios

#### 📂 **Exceptions**:
- Excepciones personalizadas del dominio

**Características**:
- No tiene dependencias de otras capas
- Define el modelo de datos del negocio
- Establece los contratos (interfaces) que otras capas deben implementar
- Contiene reglas de validación del dominio

**Tecnologías**:
- .NET 9.0 (sin dependencias externas)

---

### 4️⃣ **MechanicalWorkShopWebApi.Infrastructure** (Capa de Infraestructura)

**Responsabilidad**: Implementa los detalles técnicos de persistencia de datos y acceso a recursos externos.

**Componentes principales**:

#### 📂 **Data**:
- `WorkshopDbContext`: Contexto de Entity Framework Core que representa la sesión con la base de datos

#### 📂 **Repositories**:
- `UserRepository`: Implementación concreta de `IUserRepository`
- Implementa las operaciones CRUD sobre la base de datos

#### 📂 **Migrations**:
- Migraciones de Entity Framework Core para crear y actualizar el esquema de base de datos
- `20251121042816_InitialCreate`: Migración inicial del proyecto

**Características**:
- Implementa el patrón Repository
- Abstrae el acceso a datos mediante Entity Framework Core
- Gestiona la conexión con SQL Server
- Mantiene el historial de cambios en la base de datos mediante migraciones

**Tecnologías**:
- Entity Framework Core 9.0.0
- SQL Server (Provider)
- Entity Framework Tools (para migraciones)

**Dependencias**:
```
Infrastructure → Domain
```

---

## 🔄 Flujo de Datos

```
1. Cliente HTTP
        ↓
2. Controller (Api Layer)
        ↓
3. Service (Services Layer) ← Aplica lógica de negocio
        ↓
4. Repository Interface (Domain Layer)
        ↓
5. Repository Implementation (Infrastructure Layer)
        ↓
6. DbContext (Entity Framework)
        ↓
7. SQL Server Database
```

**Ejemplo práctico - Obtener un usuario**:

1. **Cliente**: `GET /api/users/1`
2. **UserController**: Recibe la petición HTTP
3. **IUserService**: El controlador llama al servicio
4. **UserService**: Implementa la lógica (validaciones, transformaciones)
5. **IUserRepository**: El servicio llama al repositorio mediante su interfaz
6. **UserRepository**: Implementación que usa Entity Framework
7. **WorkshopDbContext**: Ejecuta la consulta SQL
8. **SQL Server**: Retorna los datos
9. **AutoMapper**: Convierte `User` entity → `UserDto`
10. **Response**: Retorna JSON al cliente

---

## 🎯 Patrones de Diseño Implementados

### 1. **Repository Pattern**
- **Ubicación**: `Infrastructure/Repositories`
- **Propósito**: Abstrae la lógica de acceso a datos
- **Beneficio**: Permite cambiar el mecanismo de persistencia sin afectar la lógica de negocio

### 2. **Dependency Injection (DI)**
- **Ubicación**: `Program.cs`
- **Configuración**:
```csharp
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
```
- **Beneficio**: Desacoplamiento y facilita las pruebas unitarias

### 3. **DTO Pattern**
- **Ubicación**: `Domain/DTOs`
- **Propósito**: Transferir datos entre capas sin exponer entidades de dominio
- **Beneficio**: Seguridad, control de datos expuestos y optimización de payloads

### 4. **Unit of Work** (Implícito con DbContext)
- **Ubicación**: `WorkshopDbContext`
- **Propósito**: Agrupa operaciones de base de datos en transacciones
- **Beneficio**: Consistencia de datos y control transaccional

---

## 🛠️ Tecnologías y Frameworks

| Capa | Tecnología | Versión | Propósito |
|------|-----------|---------|-----------|
| **Api** | ASP.NET Core | 9.0 | Framework web |
| **Api** | Swagger | 6.5.0 | Documentación de API |
| **Api** | AutoMapper | 12.0.1 | Mapeo de objetos |
| **Services** | AutoMapper | 12.0.1 | Transformación de datos |
| **Domain** | .NET | 9.0 | Definición del modelo |
| **Infrastructure** | EF Core | 9.0.0 | ORM para acceso a datos |
| **Infrastructure** | SQL Server | - | Base de datos |

---

## 🔗 Dependencias entre Proyectos

```
Api.csproj
├── → Domain.csproj
├── → Infrastructure.csproj
└── → Services.csproj

Services.csproj
└── → Domain.csproj

Infrastructure.csproj
└── → Domain.csproj

Domain.csproj
└── (sin dependencias)
```

**Nota**: El proyecto `Domain` no tiene dependencias externas, lo que garantiza que el núcleo del negocio permanece independiente de frameworks y tecnologías específicas.

---

## ✅ Ventajas de esta Arquitectura

1. **Mantenibilidad**: Código organizado y fácil de entender
2. **Testabilidad**: Cada capa puede ser probada de forma aislada
3. **Escalabilidad**: Fácil agregar nuevas funcionalidades sin romper código existente
4. **Flexibilidad**: Cambiar tecnologías (ej: cambiar de SQL Server a PostgreSQL) sin afectar la lógica de negocio
5. **Reutilización**: La lógica de negocio puede ser reutilizada en diferentes tipos de aplicaciones (Web, Desktop, Mobile)
6. **Separación de responsabilidades**: Cada capa tiene un propósito claro y único