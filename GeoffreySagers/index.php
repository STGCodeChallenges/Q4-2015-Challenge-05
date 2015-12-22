<?php require("db.php"); ?>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title><?=$title;?></title>
<link href="css/styles.css" rel="stylesheet" type="text/css">
</head>

<body>
<div class="questionbox">
    <h2 class="ctr"><?=$title;?></h2>
    <p class="ctr">
        <a href="easy.php" class="btn">Easy</a>
        <a href="hard.php" class="btn">Hard</a>
    </p>
</div>
</body>
</html>