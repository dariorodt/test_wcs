# Desafío Back-end WCS
Test Back-end WCS

## Resumen
El Colegio de Magia y Hechicería Hogwarts requiere diseñar su sistema de inscripciones para el próximo periodo académico.

Para tal fin, se requiere exponer una API REST, construida usando el framework .NetCore(> 3.0).

Deben exponerse los endpoints necesarios para soportar las siguientes operaciones:
* Enviar Solicitud de Ingreso
* Actualizar solicitud de Ingreso
* Consultar todas las solicitudes enviadas
* Eliminar la solicitud de ingreso.

La solicitud de ingreso debe indicar como mínimo los siguientes datos del aspirante:
* Nombre (Solo letras, máximo 20 caracteres)
* Apellido (Solo letras, máximo 20 caracteres)
* Identificación (Solo números, máximo 10 dígitos)
* Edad (Solo números, máximo 2 dígitos)
* Casa a la que aspira pertenecer (Solo 4 posibles opciones: "Gryffindor", "Hufflepuff", "Ravenclaw", "Slytherin")
Cualquier solicitud de adición o edición que incumpla los criterios anteriormente descritos, debe ser descartada.

## End Points
Los end points expuestos son los siquientes:
* GET https://[nombre.dominio]/api/Admissions
* POST https://[nombre.dominio]/api/Admissions
* GET https://[nombre.dominio]/api/Admissions/{id}
* PUT https://[nombre.dominio]/api/Admissions/{id}
* DELETE https://[nombre.dominio]/api/Admissions/{id}

### GET /api/Admissions
Recupera la lista completa de las solicitudes de admisión registradas.

### POST /api/Admissions
Crea una nueva solicitud de admisión enviando los siguientes campos: Nombre, Apellido, Edad, Casa.
El Id se crea automáticamente en la base de datos al realizar el ingreso del registro.

### GET /api/Admissions/{id}
Recupera una solicitud de admisión buscándola por el Id.

### PUT /api/Admissions/{id}
Actualiza los falores de los campos de un registro identificado por su Id.

### DELETE /api/Admissions/{id}
Elimina permanentemente un registro identificado con su Id.

## Pruebas
El proyecto implementa en middleware "Swagger" para exponer la documentación necesaria para utilización de la API y una interfaz de prueba para la verificación del funcionamiento de cada endpoint.

Se puede acceder a esta herramienta a través de la URL https://[nombre.dominio]/swagger/index.html
