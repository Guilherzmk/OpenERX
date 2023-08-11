import { AddressParams } from '../models/shared/AddressParams';
import { DataFieldParams } from './shared/DataFieldParams';
import { EmailParams } from './shared/EmailParams';
import { PhoneParams } from './shared/PhoneParams';
import { SiteParams } from './shared/SiteParams';

export interface CustomerParams {
  id: string;
  code: number;
  typeCode: number;
  name: string;
  nickname: string;
  display: string;
  birthDate: string;
  personTypeCode: number;
  identity: string;
  externalCode: string;
  addresses: AddressParams[];
  phones: PhoneParams[];
  emails: EmailParams[];
  sites: SiteParams[];
  fields: DataFieldParams[];
  statusCode: number;
  statusDate: string;
  statusNote: string;
  originId: string;
  storeId: string;
  brokerId: string;
  note: string;
}
