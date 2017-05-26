import { WebApiPage } from './app.po';

describe('web-api App', () => {
  let page: WebApiPage;

  beforeEach(() => {
    page = new WebApiPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
