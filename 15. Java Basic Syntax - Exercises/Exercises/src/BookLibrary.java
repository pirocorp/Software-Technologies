import java.util.*;
import java.util.stream.Collectors;

public class BookLibrary {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int n = Integer.parseInt(scan.nextLine());

        List<Book> books = new ArrayList<>();

        for (int i = 0; i < n; i++) {
            String[] tokens = scan.nextLine().split(" ");
            String title = tokens[0];
            String author = tokens[1];
            String publisher = tokens[2];
            String releaseDate = tokens[3];
            String iSBN = tokens[4];
            double price = Double.parseDouble(tokens[5]);
            Book currentBook = new Book(title, author, publisher, releaseDate, iSBN, price);
            books.add(currentBook);
        }

        Set<String> authors = books
                .stream()
                .map(Book::getAuthor)
                .collect(Collectors.toSet());

        List<Author> result = new ArrayList<>();

        for (String author : authors) {
            double sum = books.stream()
                    .filter(b -> b.getAuthor().equals(author))
                    .mapToDouble(Book::getPrice)
                    .sum();

            Author currentAuthor = new Author(author, sum);
            result.add(currentAuthor);
        }

        result = result.stream()
                .sorted(Comparator.comparing(Author::getSum).reversed()
                        .thenComparing(Comparator.comparing(Author::getName)))
                .collect(Collectors.toList());

        for(Author entry : result) {
            String key = entry.getName();
            double value = entry.getSum();

            System.out.printf("%s -> %.2f", key, value);
            System.out.println();
        }
    }
}

class Book {
    private String title;
    private String author;
    private String publisher;
    private String releaseDate;
    private String iSBN;
    private double price;

    public Book(String title, String author, String publisher, String releaseDate, String iSBN, double price) {
        this.title = title;
        this.author = author;
        this.publisher = publisher;
        this.releaseDate = releaseDate;
        this.iSBN = iSBN;
        this.price = price;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getAuthor() {
        return author;
    }

    public void setAuthor(String author) {
        this.author = author;
    }

    public String getPublisher() {
        return publisher;
    }

    public void setPublisher(String publisher) {
        this.publisher = publisher;
    }

    public String getReleaseDate() {
        return releaseDate;
    }

    public void setReleaseDate(String releaseDate) {
        this.releaseDate = releaseDate;
    }

    public String getISBN() {
        return iSBN;
    }

    public void setISBN(String ISBN) {
        this.iSBN = ISBN;
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    @Override
    public String toString() {
        return "Book{" +
                "title='" + title + '\'' +
                ", author='" + author + '\'' +
                ", publisher='" + publisher + '\'' +
                ", releaseDate='" + releaseDate + '\'' +
                ", iSBN='" + iSBN + '\'' +
                ", price=" + price +
                '}';
    }
}

class Author {
    private String name;
    private double sum;

    public Author(String name, double grade) {
        this.name = name;
        this.sum = grade;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public double getSum() {
        return sum;
    }

    public void setSum(double sum) {
        this.sum = sum;
    }
}
