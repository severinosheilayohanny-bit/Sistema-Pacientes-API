### 👩🏻‍💻 Desarrollado por

**Sheila Yohanny Severino**  
**Matrícula:** 2024-1693  
**Institución:** Instituto Tecnológico de Las Américas (ITLA)  
**Asignatura:** Programación II  
**Año:** 2026

# 🏥 SY Health
### Sistema Integral de Gestión de Pacientes

---

## 📌 Descripción del proyecto

**SY Health** es un sistema de gestión de pacientes que desarrollé con el objetivo de aplicar los conocimientos adquiridos en Programación II, especialmente la arquitectura N-Capas, el desarrollo de API REST, el uso de interfaces y la integración de bases de datos mediante Entity Framework Core.

Para este proyecto decidí crear una aplicación web sencilla de utilizar, con una interfaz moderna y organizada, que permita administrar la información de los pacientes de manera práctica.

El sistema cuenta con un CRUD completo de pacientes y una base de datos relacional compuesta por diez tablas, diseñadas para representar diferentes elementos de un entorno médico.

## 🎯 Objetivo

Desarrollar una aplicación funcional que permita gestionar pacientes mediante una API REST construida en .NET, aplicando los principios de separación de responsabilidades y arquitectura N-Capas.

## ⚙️ Tecnologías utilizadas

| Tecnología | Uso |
|---|---|
| C# y .NET 10 | Desarrollo del backend |
| ASP.NET Core Web API | Creación de endpoints REST |
| Entity Framework Core | Acceso y persistencia de datos |
| SQL Server Express | Base de datos relacional |
| HTML5 | Estructura de la interfaz |
| CSS3 | Diseño visual y adaptación a pantallas |
| JavaScript | Funcionalidades del frontend |
| Fetch API | Comunicación con la API |
| Git y GitHub | Control de versiones |

## 🏗️ Arquitectura N-Capas

Organicé el proyecto en cuatro capas para mantener las responsabilidades separadas:

**1. Pacientes.Domain**

Contiene las entidades del sistema y las interfaces que definen los contratos de acceso a datos.

**2. Pacientes.Application**

Contiene las interfaces y los servicios encargados de coordinar las operaciones de la aplicación y aplicar validaciones básicas.

**3. Pacientes.Infrastructure**

Implementa el acceso a SQL Server mediante Entity Framework Core. Incluye el contexto de base de datos, las migraciones y el repositorio de pacientes.

**4. Pacientes.API**

Expone los endpoints REST y configura la inyección de dependencias. También aloja la interfaz web desarrollada con HTML, CSS y JavaScript puro.

Esta estructura permite que el controlador no acceda directamente a la base de datos, sino que utilice los servicios y repositorios correspondientes.

## 🗄️ Base de datos

Utilicé **Entity Framework Core Code First** para crear la base de datos `PacientesDB`, compuesta por diez tablas relacionadas:

1. Patients
2. Doctors
3. Specialties
4. Departments
5. Appointments
6. MedicalRecords
7. Diagnoses
8. Medications
9. Prescriptions
10. PrescriptionDetails

Estas tablas representan pacientes, médicos, especialidades, departamentos, citas, historiales médicos, diagnósticos, medicamentos y recetas.

El proyecto incluye las migraciones necesarias para generar la estructura de la base de datos.

## 💻 Funcionalidades implementadas

El sistema permite:

- Registrar nuevos pacientes.
- Consultar todos los pacientes registrados.
- Buscar pacientes por su identificador.
- Actualizar la información de un paciente.
- Eliminar pacientes, siempre que no tengan registros relacionados que impidan la eliminación.
- Buscar pacientes por nombre o cédula desde la interfaz.
- Actualizar el listado sin recargar toda la página.

También implementé validaciones básicas para los campos obligatorios y una restricción de unicidad para la cédula.

## 🔗 Endpoints de la API

| Método | Endpoint | Descripción |
|---|---|---|
| GET | `/api/patients` | Consultar todos los pacientes |
| GET | `/api/patients/{id}` | Consultar un paciente por ID |
| POST | `/api/patients` | Registrar un paciente |
| PUT | `/api/patients/{id}` | Actualizar un paciente |
| DELETE | `/api/patients/{id}` | Eliminar un paciente |

## 🎨 Interfaz web

Para el frontend utilicé **HTML, CSS y JavaScript puro (Vanilla JS)**, sin emplear MVC.

Elegí una combinación de violeta, azul marino y blanco para transmitir una apariencia moderna y profesional.

La interfaz incluye un formulario de registro, una tabla de pacientes, un buscador y botones para editar y eliminar registros.

La comunicación con el backend se realiza mediante `fetch()`, consumiendo los endpoints de la API REST.

## 🚀 Ejecución del proyecto

Para ejecutar SY Health localmente:

1. Clonar o descargar este repositorio.
2. Abrir la solución `PacientesSystem.slnx` en Visual Studio 2026.
3. Tener instalado .NET 10 y SQL Server.
4. Configurar la cadena de conexión `DefaultConnection` en `Pacientes.API/appsettings.json`, según la instancia local de SQL Server.
5. Aplicar las migraciones de Entity Framework Core.
6. Establecer `Pacientes.API` como proyecto de inicio.
7. Ejecutar la aplicación desde Visual Studio.

Para aplicar las migraciones desde Package Manager Console:

```powershell
Update-Database -Project Pacientes.Infrastructure -StartupProject Pacientes.API -Context ApplicationDbContext
```

Al iniciar el proyecto, la interfaz web estará disponible en la dirección local HTTPS asignada por Visual Studio.

## 🧪 Pruebas realizadas

Durante el desarrollo comprobé las principales funcionalidades del sistema:

- Registro de pacientes desde la interfaz web.
- Consulta y visualización de los registros.
- Edición de datos existentes.
- Búsqueda por nombre y cédula.
- Eliminación de pacientes.
- Actualización del listado después de cada operación.

Las pruebas se realizaron utilizando la aplicación web conectada a la API y a SQL Server.

## 💜 Reflexión personal

Este proyecto me permitió reforzar mis conocimientos sobre el desarrollo de aplicaciones en .NET y comprender mejor cómo se comunican las diferentes capas de un sistema.

Uno de los aspectos que más me interesó fue conectar una interfaz desarrollada con JavaScript a una API REST y comprobar cómo las operaciones realizadas desde el navegador se reflejan directamente en SQL Server.

También pude aplicar interfaces, inyección de dependencias, programación asíncrona, repositorios y migraciones de Entity Framework Core.

Más allá de completar la asignación, SY Health representa una oportunidad para seguir fortaleciendo mis habilidades como desarrolladora de software.
