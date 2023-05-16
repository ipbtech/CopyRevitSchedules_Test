# CopyRevitSchedules

## Основные технологии
1. .NET Framework 4.7
2. LINQ
3. Revit API 2020
4. WPF
5. WinForms

## Назначение и логика работы
Плагин предназначен для пакетного копирования спецификаций из текущего проекта (откуда выполняется запуск) в список моделей, который подается в плагин в виде .txt файла с полными абсолютными путями к обрабатываемым моделям. Для моделей Для моделей раздела КР после копирования плагин также меняет значение фильтра в зависимости от имени обрабатываемой модели (значение поля "_КЖ2.1" в имени модели). Имена копируемых спецификаций зашиты в коде.
Результаты выполнения программы пишктся в отчет, который появляется после обработки всех файлов, где по каждому обрабатываемому файлу указавыется:
 - Полный путь до него
 - Результат работы
 - Время обработки файла 
 - Общее время обработки всех файлов
  
## Установка и запуск
Скопировать содержимое папки __prod__ в папку с плагинами для подгрузки их в Revit: **C:\Users\%username%\AppData\Roaming\Autodesk\Revit\Addins\2020**
При запуске Revit в появившемся окне выбрать "Всегда загружать" или "Загрузить один раз".

![Загрузка в Revit](https://github.com/ipbtech/CopyRevitSchedules_Test/blob/e23bb30254eea8c0d44bce3415895202e0313955/Raw/1.png)

## Интерфейс
![Интерфейс](https://github.com/ipbtech/CopyRevitSchedules_Test/blob/21874c130688f37e293f69238a180fbebc4231c6/Raw/2.png)

1. Загрузка .txt файла с полными путями к обрабатываемым моделям (открывается диалоговое окно с директорией по умолчанию "Рабочий стол")
2. Вспомогательное окно, в котором отображаются имена моделей для обрбаботки после загрузки .txt файла
3. Выборка спецификаций АР из текущего проекта (при отжатии галочки выборка очищается)
4. Выборка спецификаций КР из текущего проекта (при отжатии галочки выборка очищается)
5. Кнопка запуска программы

## Требования для корреткной работы
Для запуска плагина на вход должен быть подан .txt файл со списком путей к обрабатываемым моделям, а также выбраны либо спецификации АР, либо спецификации КР (либо и то, и то). При попытке холостого запуска будет показано уведомляющее окно. Если при нажатии галочки Копирование спецификаций АР/Копирование спецификаций КР, данные спецификации не найдены в проекте будет также показано уведомляющее окно.
