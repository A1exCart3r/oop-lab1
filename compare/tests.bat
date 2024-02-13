chcp 65001

REM Запуск программы с неправильным количеством аргументов выведет руководство 
compare.exe file1.txt && goto err
echo Тест 1 пройден

REM Указание несуществующих файлов приведет к ошибке
compare.exe missingfile1.txt missingfile2.txt && goto err
echo Тест 2 пройден

REM Обычное сравнение одинаковых файлов должно быть без ошибок
compare.exe file1.txt file2.txt || goto err
echo Тест 3 пройден

REM Обычное сравнение разных файлов должно быть без ошибок, вдобавок идет проверка на разное количество строк
compare.exe file3.txt file4.txt || goto err
echo Тест 4 пройден

REM Сравнение пустого файла с не пустым должно быть без ошибок
compare.exe emptyfile1.txt file2.txt || goto err
echo Тест 5 пройден

REM Сравнение пустых файлов скажет что файлы равны
compare.exe emptyfile1.txt file2.txt || goto err
echo Тест 6 пройден

REM Тесты пройдены
echo Тесты пройдены
exit /b 0

:err
echo Тесты провалены
exit /b 1