<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
    <form>
        N: <input type="text" name="num" />
        <input type="submit" />
    </form>
    <?php
    if(isset($_GET['num'])){
        $n = intval($_GET['num']);
        $prevNum = 0;
        $currentNum = 1;
        for ($i = 1; $i <= $n; $i++){
            $numbers[] = $currentNum;
            $nextNum = $prevNum + $currentNum;
            $prevNum = $currentNum;
            $currentNum = $nextNum;
        }
        echo implode(" ", $numbers);
    }
    ?>
</body>
</html>