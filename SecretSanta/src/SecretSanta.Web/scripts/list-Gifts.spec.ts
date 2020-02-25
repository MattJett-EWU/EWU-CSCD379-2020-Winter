import { ListGifts } from './list-Gifts';
import { expect } from 'chai';
import 'mocha';
import { IGiftClient, GiftInput, Gift } from './secretsanta-client';

describe('getAllGifts', () => {
    it('should return the gifts', async () => {
        const listGifts = new ListGifts(new MockGiftClient());
        const actual = await listGifts.getAllGifts();
        expect(actual.length).to.equal(1);
    });
});

class MockGiftClient implements IGiftClient {
    async getAll(): Promise<Gift[]> {
        return [
            new Gift({
                id: 42,
                title: 'Princess Bride',
                description: 'The best movie ever made',
                url: 'https://www.princessbride.com/',
                userId: 42
            })
        ];
    }

    get(id: number): Promise<Gift> {
        throw new Error('Method not implemented.');
    }

    put(id: number, value: GiftInput): Promise<Gift> {
        throw new Error('Method not implemented.');
    }

    post(entity: GiftInput): Promise<Gift> {
        throw new Error('Method not implemented.');
    }

    delete(id: number): Promise<void> {
        throw new Error('Method not implemented.');
    }
}
