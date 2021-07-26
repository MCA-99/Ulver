<?php 
    try {
        $hostname = "172.17.0.1";
        $dbname = "db";
        $username = "admin";
        $pw = "admin";
        $pdo = new PDO ("mysql:host=$hostname;dbname=$dbname","$username","$pw");
    } catch (PDOException $e) {
        echo "Failed to get DB handle: " . $e->getMessage() . "\n";
        exit;
    }
?>

<html>

    <head>
        <title>Ulver</title>
        <link rel="stylesheet" href="../css/style.css">
    </head>

    <body>
        <div class="title"><a href="../index.html">u lv e r</a></div>
        <?php
            $query = $pdo->prepare("SELECT jugador, tiempo, saved_on FROM tiempos ORDER BY tiempo");
            $query->execute();

            echo "<center><table style='font-size: 36px; align: center; border-spacing: 30px;'>";
            echo "<tr><td>jugador</td><td>tiempo</td><td>fecha</td></tr>";
            foreach($query as $key => $row){
                echo "<tr><td>".$row['jugador']."</td><td>".$row['tiempo']."</td><td>".$row['saved_on']."</td></tr>";
            } 
            echo "</table></center>";
        ?>
    </body>

</html>