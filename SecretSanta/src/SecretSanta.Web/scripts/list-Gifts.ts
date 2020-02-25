import {
    IGiftClient,
    GiftClient,
    IGift
} from './secretsanta-client';

export class ListGifts {
    private giftClient: IGiftClient;

    public constructor(giftClient: IGiftClient = new GiftClient()) {
        this.giftClient = giftClient;
    }

    public async renderGifts(): Promise<void> {
        const gifts: IGift[] = await this.getAllGifts();
        const elements: HTMLElement[] = gifts.map(gift => {
            const e: HTMLElement = document.createElement('li');
            e.textContent = `${gift.id}:${gift.title}:${gift.description}:${gift.url}`;
            return e;
        });
        const giftList: HTMLElement = document.getElementById('giftList');
        elements.forEach(e => giftList.append(e));
    }

    public async generateGiftList(): Promise<void> {
        throw new Error('Method not implemented.');
    }

    public async getAllGifts(): Promise<IGift[]> {
        return await this.giftClient.getAll();
    }
}