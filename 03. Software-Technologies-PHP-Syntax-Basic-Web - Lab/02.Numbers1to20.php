<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Hello PHP</title>
</head>
<body>

<ul>
    <?php for($i = 1; $i <= 20; $i++) {
        if($i % 2 == 0){
            $color = "green";
        }
        else{
            $color = "blue";
        }
        echo"<li style='color: $color'>$i</li>";
        } ?>
</ul>

</body>
</html>