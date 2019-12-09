# BasketballSim

Basketball Simulator C#

## Logica de juego

1. <http://oluwatobipopoola.com/basketball-simulation-app-swift-part-1/.>
2. <http://oluwatobipopoola.com/http-oluwatobipopoola-com-basketball-simulation-app-swift-part-2/.>
3. <http://oluwatobipopoola.com/nba-season-scheduler-with-swift/.>
4. <http://oluwatobipopoola.com/basketball-player-swift/.>
5. <https://en.wikipedia.org/wiki/Round-robin_tournament#Scheduling_algorithm.>

## Useful Info or Tutorials

GIT Commands: <https://dev.to/dhruv/essential-git-commands-every-developer-should-know-2fl>
SQLite Net.Core: <https://developersoapbox.com/connecting-to-a-sqlite-database-using-net-core/>
Unity3D SQL: <https://hackernoon.com/implementing-backend-for-unity3d-games-using-php-6f043b5b7db7>
Unity3D SQLite: <https://medium.com/@rizasif92/sqlite-and-unity-how-to-do-it-right-31991712190>
API CRUD: <http://vbpuntonet.blogspot.com/2018/06/api-rest-creacion-de-un-api-rest-crud.html>
SQLite Docs: <https://www.tutorialspoint.com/sqlite/index.htm>

## Changelog

### 09/12

- Actualiza BoxScore del partido con todas las stats
- Actualiza Stats de la liga para todos los players
- Ahora da el PPG del top scorer

### 06/12

- Ahora levanta los jugadores y los equipos desde la DB
- Falta hacer que suba la información

### 04/12

- BoxScore actualizado
- PlayerTendencies
- PlayerTypes
- Team Records (y Ordenados)
- Top Scorer informado al final de la liga (Faltan los PPG)
- Contabiliza Asistencias, Blockeos, Robos, FGM, FGA, 3PM, 3PA

### 01/12

- Empieza la generación de la liga.
- Agregue el Simulador.
- Hay más nombres para evitar duplicados.

### 29/11 - 12:30

- Se agregó la generación de nombres por nombre y apellido.
- Se agregó el diccionario del BoxScore para los equipos.
- Se modificó el output de cada partido.
- Se modificó el readme.

#### Known Bugs AND TO-DOs

- Si se crean jugadores con el mismo nombre dentro de un equipo, da un error.
- Hay que buscar una forma más eficiente de manejar datos que los diccionarios.
