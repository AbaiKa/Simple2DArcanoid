# Simple2DArcanoid
 * ТЗ было выполнено в течении 10-15 часов. Все настройки были вынесены в SO в папку Assets/Data
 
Количество врагов, которое следует уничтожить для победы (range int); при каждом запуске игры количество врагов выбирается случайным образом из диапазона [min, max];
- за эту настройку отвечает SO Wave_Simple, где WaveEndMin и WaveEndMax это диапазон врагов, которое следует уничтожить для победы
- 
Таймаут с которым враги появляются (range float), следующий враг появляется через случайное число секунд из диапазона [min, max];
- За них отвечает SpawnTimeMin и SpawnTimeMax

  
Скорость движения врагов (range float), скорость каждого нового врага выбирается случайно из диапазона [min, max];
- За настройку врагов отвечает SO Enemy_Simple SpeedMin и SpeedMax
- 
Количество здоровья врагов (int);
- SO Enemy_Simple -> Health

  
Радиус поражения(стрельбы) персонажа (float);
- за эти настройки отвечает SO Weapon_Ranged -> Attack Range
- 
Скорость стрельбы персонажа (float);
- Weapon_Ranged -> Shoots Per Second
- 
Урон от выстрела персонажа (int);
- Weapon_Ranged -> Bullet Data -> Damage
- 
Скорость пули (float).
- Weapon_Ranged -> Bullet Data -> Speed


Все ScriptableObjects в папке "SAssets/Data"
