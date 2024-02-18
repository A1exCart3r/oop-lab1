chcp 65001

REM Обычное слияние нескольких файлов
join.exe "file1.dat" "file2.dat" "file3.dat" "output.dat" || goto err
echo Тест 1 пройден

REM Указание несуществующих файлов приведет к ошибке
join.exe "missingfile1.dat" "file2.dat" "missingfile3.dat" "output.dat" && goto err
echo Тест 2 пройден

REM Недостаточное количество аргументов выведет инструкцию
join.exe "file1.dat" "output.dat" && goto err
echo Тест 3 пройден


REM Если один из файлов пустой, программа обработается корректно
join.exe "emptyfile.dat" "file2.dat" "file3.dat" "output.dat" || goto err
echo Тест 2 пройден

echo Тесты пройдены
exit /b 0

:err
echo Тесты не пройдены
exit /b 1