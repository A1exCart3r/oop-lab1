chcp 65001

REM Запуск программы с неправильным количеством аргументов выведет руководство 
compare.exe file1.txt && goto err
echo Тест 1 пройден

REM Указание несуществующих файлов приведет к ошибке
compare.exe missingfile1.txt missingfile2.txt && goto err
echo Тест 2 пройден

REM Обычное сравнение файлов без ошибок
compare.exe file1.txt file2.txt || goto err
echo Тест 3 пройден

REM Тесты пройдены
echo Тесты пройдены
exit /b 0

:err
echo Тесты провалены
exit /b 1