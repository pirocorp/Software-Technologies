import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.Scanner;

public class CountWorkingDays {
    public static void main(String[] args) throws Exception {
        Scanner scan = new Scanner(System.in);

        SimpleDateFormat sdf = new SimpleDateFormat("dd-MM-yyyy");

        Date startDate = sdf.parse(scan.nextLine());
        Date endDate = sdf.parse(scan.nextLine());

        Calendar s = Calendar.getInstance();
        s.setTime(startDate);
        Calendar e = Calendar.getInstance();
        e.setTime(endDate);
        e.add(Calendar.DATE, 1);

        Date[] officialHolidays = getHolidaysDates(sdf);

        int workingDays = 0;

        for (Calendar i = s; i.before(e); i.add(Calendar.DATE, 1)) {

            if(isWorkingDay(i, officialHolidays)){
                workingDays++;
            }
        }

        System.out.println(workingDays);
    }

    private static Date[] getHolidaysDates(SimpleDateFormat sdf) throws ParseException {
        Date[] officialHolidays = new Date[11];

        String[] officialHolidaysAsStrings = {
                "01-01-2014", "03-03-2014", "01-05-2014", "06-05-2014",
                "24-05-2014", "06-09-2014", "22-09-2014", "01-11-2014",
                "24-12-2014", "25-12-2014", "26-12-2014"};

        for (int i = 0; i < officialHolidays.length; i++) {
            Date currentDate = sdf.parse(officialHolidaysAsStrings[i]);
            officialHolidays[i] = currentDate;
        }
        return officialHolidays;
    }

    private static boolean isWorkingDay(Calendar date, Date[] officialHolidays) {

        int currentDay = date.get(Calendar.DAY_OF_MONTH);
        int currentMonth = date.get(Calendar.MONTH);
        int dayOfWeek = date.get(Calendar.DAY_OF_WEEK);

        if(dayOfWeek == 7 || dayOfWeek == 1){
            return false;
        }

        Calendar currentHoliday = Calendar.getInstance();

        for (int j = 0; j < officialHolidays.length; j++) {
            currentHoliday.setTime(officialHolidays[j]);
            int currentHolidayDay = currentHoliday.get(Calendar.DAY_OF_MONTH);
            int currentHolidayMonth = currentHoliday.get(Calendar.MONTH);

            if(currentHolidayDay == currentDay && currentHolidayMonth == currentMonth){
                return false;
            }
        }

        return true;
    }
}
