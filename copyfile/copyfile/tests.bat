chcp 65001

REM Обычное копирование файла 
copyfile.exe file3.txt file4.txt || goto err
fc file3.txt file4.txt > nul || goto err
echo Тест 1 пройден

REM Копирование несуществующего файла выведет ошибку
copyfile.exe missingFile.txt file4.txt && goto err
echo Тест 2 пройден

REM Копирование пустого файла
copyfile.exe Empty.txt EmptyCopy.txt
fc Empty.txt EmptyCopy.txt > nul || goto err
echo Тест 3 пройден

REM Запуск программы с неправильным количеством аргументов выведет руководство
copyfile.exe file1.txt && goto err
echo Тест 4 пройден

Rem Недопустимое имя файла выведет ошибку
copyfile.exe file1.txt file?@2.png && goto err

REM Тесты пройдены
echo Тесты пройдены
exit /b 0

:err
echo Тест провален
exit /b 1