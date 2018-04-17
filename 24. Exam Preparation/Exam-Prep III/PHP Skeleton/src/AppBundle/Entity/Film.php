<?php

namespace AppBundle\Entity;

use Doctrine\ORM\Mapping as ORM;

/**
 * Film
 *
 * @ORM\Table(name="films")
 * @ORM\Entity(repositoryClass="AppBundle\Repository\FilmRepository")
 */
class Film
{
    /**
     * @var int
     *
     * @ORM\Column(name="id", type="integer")
     * @ORM\Id
     * @ORM\GeneratedValue(strategy="AUTO")
     */
    private $id;

    /**
     * @var string
     *
     * @ORM\Column(name="name", type="string", length=2000)
     */
    private $name;

    /**
     * @var string
     * @
     * @ORM\Column(name="genre", type="string", length=200)
     */
    private $genre;

    /**
     * @var string
     * @
     * @ORM\Column(name="director", type="string", length=200)
     */
    private $director;

    /**
     * @var int
     * @
     * @ORM\Column(name="year", type="integer")
     */
    private $year;

    /**
     * @return int
     */
    public function getId()
    {
        return $this->id;
    }

    /**
     * @param int $id
     */
    public function setId($id)
    {
        $this->id = $id;
    }

    /**
     * @return string
     */
    public function getName()
    {
        return $this->name;
    }

    /**
     * @param string $name
     */
    public function setName($name)
    {
        $this->name = $name;
    }

    /**
     * @return string
     */
    public function getGenre()
    {
        return $this->genre;
    }

    /**
     * @param string $genre
     */
    public function setGenre($genre)
    {
        $this->genre = $genre;
    }

    /**
     * @return string
     */
    public function getDirector()
    {
        return $this->director;
    }

    /**
     * @param string $director
     */
    public function setDirector($director)
    {
        $this->director = $director;
    }

    /**
     * @return int
     */
    public function getYear()
    {
        return $this->year;
    }

    /**
     * @param int $year
     */
    public function setYear($year)
    {
        $this->year = $year;
    }
}
