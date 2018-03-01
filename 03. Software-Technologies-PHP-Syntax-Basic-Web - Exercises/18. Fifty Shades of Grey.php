<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
    <style>
        div {
            display: inline-block;
            margin: 5px;
            width: 20px;
            height: 20px;
        }
    </style> 
</head>
<body>
<?php
for ($i = 0; $i < 5; $i++) {
    for ($j = 0; $j < 10; $j++) {
        $colorIndex = $i * 50 + $i + $j * 5;
        $div = "<div style='background-color: rgb($colorIndex, $colorIndex, $colorIndex)'></div>";
        echo $div;
    } ?>
    <br>
<?php }
?>
</body>
</html>