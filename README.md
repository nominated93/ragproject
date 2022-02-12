# ragproject
RPG Game in C# (Unity)

###### :white_small_square: 각 기능을 하는 Manager들을 생성하여 최초 한번만 메모리에 할당하고, 어느 클래스에서도 접근이 가능하도록 했다.(Singleton) 여러 개의 Manager를 관리할 수 있는 Manager를 따로 생성하여 여러 개의 Manager를 통합하여 제어할 수 있도록 했다.
 -   [Managers.cs](Assets/Scripts/Managers/Managers.cs)
 -   [SceneManagerEx.cs](Assets/Scripts/Managers/Core/SceneManagerEx.cs)
 -   [CameraManager.cs](Assets/Scripts/Managers/Contents/CameraManager.cs)
 -   [ObjectManager.cs](Assets/Scripts/Controllers/ObjectManager.cs)
 -   [MapManager.cs](Assets/Scripts/Managers/Contents/MapManager.cs)
 -   …


###### :white_small_square: 움직이는 객체(Player, Monster 등) 컨트롤러는 전부 Creature를 상속받아 공통 모듈(충돌, 이동 등)을 CreatureController에서 관리하고, 다른 부분은 해당 컨트롤러에서 제어 한다. 또한 맵 이동시 빈번한 객체 생성 및 삭제 처리가 불필요한 객체(Player, Camera, Manager 등)는 인스턴스화 하였다.
-   [CreatureController.cs](Assets/Scripts/Controllers/CreatureController.cs)
-   [MonsterController.cs](Assets/Scripts/Controllers/MonsterController.cs)
-   [PlayerController.cs](Assets/Scripts/Controllers/PlayController.cs)


###### :white_small_square: 일반 맵(tilemap_base) 외에 collision 오브젝트를 따로 관리하는 맵 객체(tilemap_collision)를 생성하고, 해당 맵을 이용하여 맵 파일(.txt)을 생성한다. 해당 기능은 메뉴(Tools-GenerateMap)를 따로 추가하여 사용했다.
-   [MapEditor.cs](Assets/Editor/MapEditor.cs)
