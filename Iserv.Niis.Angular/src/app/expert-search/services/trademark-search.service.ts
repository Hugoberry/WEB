import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';

import { ErrorHandlerService } from '../../core/error-handler.service';
import { ConfigService } from '../../core/index';
import { SnackBarHelper } from '../../core/snack-bar-helper.service';
import { BaseServiceWithPagination } from '../../shared/base-service-with-pagination';
import { TrademarkDto, TrademarkSearchDto } from '../models/trademark-dto.model';


@Injectable()
export class TrademarkSearchService extends BaseServiceWithPagination<TrademarkSearchDto> {
  private api = '/api/search/expert/trademark/';

  constructor(http: HttpClient,
    configService: ConfigService,
    errorHandlerService: ErrorHandlerService,
    private snackBarHelper: SnackBarHelper) {
    super(http, configService, errorHandlerService, '/api/search/expert/trademark/');
  }

  public get(): Observable<TrademarkSearchDto[]> {
    return this.http.get(`${this.configService.apiUrl}${this.api}`)
      .catch(err => this.errorHandlerService.handleError.call(this.errorHandlerService, err))
      .map((data: TrademarkSearchDto[]) => data);
  }

  public getExcel(keyValuePairs: any[]): Observable<any> {
    const params = this.buildQueryString(keyValuePairs);

    return this.http
      .get(`${this.configService.apiUrl}${this.api}/getexcel`,
      { observe: 'response', params: new HttpParams({ fromString: params }), responseType: 'blob' })
      .catch(err => this.errorHandlerService.handleError.call(this.errorHandlerService, err));
  }

  private buildQueryString(keyValuePairs: any[] = []): string {
    return keyValuePairs
      .filter(item => item.value !== undefined && item.value.toString().length)
      .map(item => `${item.key}=${item.value}`)
      .join('&');
  }
}
