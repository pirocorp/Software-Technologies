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
        $previusNum  = 0;
        $currentNum = 0;
        $nextNum = 1;
        $n = intval($_GET['num']);
        for ($i = 1; $i <= $n; $i++){
            $numbers[] = $nextNum;
            $newNextNum = $previusNum + $currentNum + $nextNum;
            $previusNum = $currentNum;
            $currentNum = $nextNum;
            $nextNum = $newNextNum;
        }
        echo implode(" ", $numbers);
    }
    ?>
</body>
</html>