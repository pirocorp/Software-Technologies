<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
</head>
<body>
<?php
$sArr = array(
        array(1,1,1,1,1),
        array(1,0,0,0,0),
        array(1,0,0,0,0),
        array(1,0,0,0,0),
        array(1,1,1,1,1),
        array(0,0,0,0,1),
        array(0,0,0,0,1),
        array(0,0,0,0,1),
        array(1,1,1,1,1)
);
    for ($i = 0; $i < 9; $i++) {
        for ($j = 0; $j < 5; $j++) {
            if($sArr[$i][$j] == 1){
                echo"<button style='background-color: blue'>1</button>";
            }else{
                echo"<button>0</button>";
            }
        } ?>
        <br>
    <?php } ?>
</body>
</html>