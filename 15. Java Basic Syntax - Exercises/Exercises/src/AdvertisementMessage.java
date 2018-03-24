import java.util.Random;

public class AdvertisementMessage {
    public static void main(String[] args) {
        String[] phrases = {"Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can't live without this product."};

        String[] events = {"Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"};

        String[] authors = {"Diana",
                "Petya",
                "Stella",
                "Elena",
                "Katya",
                "Iva",
                "Annie",
                "Eva"};

        String[] cities = {"Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse"};

        String phrase, event, author, city;

        Random rand = new Random();

        phrase = phrases[rand.nextInt(phrases.length)];
        event = events[rand.nextInt(events.length)];
        author = authors[rand.nextInt(authors.length)];
        city = cities[rand.nextInt(cities.length)];

        System.out.printf("%s %s %s - %s", phrase, event, author, city);
    }
}
