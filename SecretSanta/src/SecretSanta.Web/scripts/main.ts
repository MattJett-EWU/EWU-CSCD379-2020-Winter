import '../styles/site.scss';
import { ListGifts } from "./list-Gifts"

const listgift: ListGifts = new ListGifts();
listgift.generateGiftList()
        .then(() =>
            listgift.renderGifts()
        );
