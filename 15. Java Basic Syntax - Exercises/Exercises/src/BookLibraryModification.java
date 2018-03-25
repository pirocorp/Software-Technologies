import java.text.SimpleDateFormat;
import java.util.*;
import java.util.stream.Collectors;

public class BookLibraryModification {
    public static void main(String[] args) throws Exception {
        Scanner scan = new Scanner(System.in);
        SimpleDateFormat sdf = new SimpleDateFormat("dd.MM.yyyy");
        int n = Integer.parseInt(scan.nextLine());

        List<Books> books = new ArrayList<>();

        for (int i = 0; i < n; i++) {
            String[] tokens = scan.nextLine().split(" ");
            String title = tokens[0];
            String author = tokens[1];
            String publisher = tokens[2];
            String releaseDateAsString = tokens[3];
            Date releaseDate = sdf.parse(releaseDateAsString);
            String iSBN = tokens[4];
            double price = Double.parseDouble(tokens[5]);
            Books currentBook = new Books(title, author, publisher, releaseDate, iSBN, price);
            books.add(currentBook);
        }

        Date inputDate = sdf.parse(scan.nextLine());

        List<Books> result = books
                .stream()
                .filter(b -> b.getReleaseDate().after(inputDate))
                .sorted(Comparator.comparing(Books::getReleaseDate)
                        .thenComparing(Books::getTitle))
                .collect(Collectors.toList());

        for(Books entry : result) {
            String key = entry.getTitle();
            String value = sdf.format(entry.getReleaseDate());

            System.out.printf(key + " -> " + value);
            System.out.println();
        }
    }
}

class Books {
    private String title;
    private String author;
    private String publisher;
    private Date releaseDate;
    private String iSBN;
    private double price;

    public Books(String title, String author, String publisher, Date releaseDate, String iSBN, double price) {
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

    public Date getReleaseDate() {
        return releaseDate;
    }

    public void setReleaseDate(Date releaseDate) {
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

class Authors {
    private String name;
    private double sum;

    public Authors(String name, double grade) {
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
