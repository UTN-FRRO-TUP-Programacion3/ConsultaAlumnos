# Proceso de Consultas de alumnos
## Contexto
La UTN dispone que los profesores de la Tecnicatura Universitaria de Programación (TUP) destinen una cierta disponibilidad para atender las consultas de sus alumnos en base a dudas que estos puedan tener sobre un aspecto de la materia que cada profesor dicta. De esta manera cada alumno puede consultar sobre una materia de forma extracurricular y obtener una respuesta del profesor de la materia a la cual está preguntando. 

## Proceso actual
Cuando un alumno de la TUP desea hacer una consulta sobre una materia, busca el listado de profesores de dicha materia para encontrar el mail del profesor al cual le quiere hacer la consulta. El alumno redacta la consulta y envía el mail, indicando en el asunto del mail: la carrera, la materia y título de la consulta.

El profesor recibe el mail y en un momento determinado responde la consulta. Existen casos en donde el profesor no llega a entender la consulta con la descripción del alumno por lo que le puede repreguntar al alumno para que este se explaye en la descripción de la duda. También se puede dar que el profesor no pueda responder de forma adecuada a través del envío de un mail, si este es el caso este puede proponer al alumno resolver la consulta por medio de una videollamada o una reunión presencial en la Facultad. Esta invitación también puede ser realizada por el alumno. Si ambos llegan a un acuerdo entonces pueden decidir un día y una hora y llevar adelante la clase de consulta.

Existen otros casos en donde la consulta pueda ser realizada por uno o más alumnos, también hay situaciones que se añadan alumnos interesados a la consulta en determinado momento del ciclo de vida de la consulta. Se podría decir que la consulta tiene 4 estados:

- Esperando respuesta del profesor: cuando la consulta fue hecha y el profesor no ha respondido o cuando el alumno respondió y se requiere una nueva intervención del profesor. 
- Esperando respuesta del alumno: cuando el profesor respondió al alumno y se requiere intervención de este.
- Resuelta: Cuando el alumno o el profesor considera que la consulta fue resuelta.
- Cancelada: una consulta puede cancelarse cuando la misma caducó por falta de actividad o bien porque la resolución de la misma fue imposible, este estado puede ser determinado por el profesor o el alumno.

## Proceso con el sistema de información deseado
Cuando un **alumno** desea hacer una **consulta** accede al sistema de consultas con su **usuario** y contraseña. El sistema despliega un portal en donde aparecen las opciones disponibles del alumno, el alumno selecciona la opción nueva consulta, el sistema despliega los campos necesarios a completar para crear la consulta.

El alumno selecciona de un desplegable, que muestra las **materias** a las que el alumno tiene acceso para consultas, la materia a la cual corresponde la consulta. El sistema, luego de haber seleccionado la materia, autocompleta el desplegable de **docentes** con aquellos docentes que corresponden a la materia seleccionada. El alumno selecciona el docente a quien quiere hacer su consulta.

Si el alumno desea puede añadir a otros compañeros como seguidores. Para hacerlo los selecciona de un desplegable en donde figuran todos los alumnos a los que corresponde la materia seleccionada. Al hacerlo cualquiera de estos alumnos puede acceder a la consulta en su portal y participar de la misma.

Para terminar de dar el alta de la consulta el usuario agrega un título y una descripción a la consulta así como archivos adjuntos si así lo considera conveniente.

Por último el usuario da de alta la consulta. El sistema notifica al profesor de que la consulta le ha sido asignada por medio de un mail.

El profesor cuando así lo desee ingresa al portal de consulta y selecciona el menú de sus consultas filtrándose por estado para poder ver aquellas consultas que están esperando su **respuesta**. El sistema las ordena por orden de antigüedad. El profesor interviene en las consultas que desea ya sea respondiendo como también cambiandolas de estado a resueltas si así lo considera.


El alumno también es notificado cuando el profesor respondió la consulta y/o la cambio a estado resuelta o cancelada. El puede acceder a la consulta y marcarla como resuelta si no lo estuviera y así lo considerase. También puede repreguntar al profesor, si este fuera el caso la pregunta pasa a estado “Esperando respuesta del profesor” sin importar el estado en  el que estuviese la pregunta.

Tanto el alumno como el profesor pueden decidir cancelar una pregunta, el sistema también puede hacerlo por inactividad del alumno, es decir si la pregunta estuvo más de cierto tiempo en estado “Esperando respuesta del X” sin ningún tipo de actividad entonces pasa a estado cancelada.
