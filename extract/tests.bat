chcp 65001

REM Обычное извлечение фрагмента
extract.exe "file1.dat" "file2.dat" 2 12 || goto err
echo Тест 1 пройден

REM Ввод несуществующего входного файла приведет к ошибке
extract.exe "missingFile.dat" "file2.dat" 2 12 && goto err
echo Тест 2 пройден

REM Ввод отрицательной стартовой позиции приведет к ошибке
extract.exe "file1.dat" "file2.dat" -2 12 && goto err
echo Тест 3 пройден

REM Ввод отрицательной длины фрагмента приведет к ошибке
extract.exe "file1.dat" "file2.dat" 2 -1 && goto err
echo Тест 4 пройден

REM Если размер фрагмента вышел за пределы, то извлечется всё до конца файла без ошибок
extract.exe "file1.dat" "file2.dat" 2 18 || goto err
echo Тест 5 пройден

REM Тест при значении размера фрагмента 0 - на выходе пустой файл
extract.exe "file1.dat" "file2.dat" 2 0 || goto err
echo Тест 6 пройден

REM Некорекктное имя выходного файла - ошибка
extract.exe "file1.dat" "file?2.dat" 2 0 && goto err
echo Тест 7 пройден

REM Неверное количество аргументов вызовет гайд
extract.exe "file1.dat" "file2.dat" 2 && goto err
echo Тест 8 пройден

REM Неправильно введеные аргументы приведут к ошибке
extract.exe "file1.dat" "file2.dat" 2 ? && goto err
echo Тест 9 пройден

REM Тесты пройдены
echo Тесты пройдены
exit /b 0

:err
echo Тесты провалены
exit /b 1