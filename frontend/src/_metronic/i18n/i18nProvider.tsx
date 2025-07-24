import {FC, useEffect} from 'react'
import {useLang} from './Metronici18n'
import {IntlProvider} from 'react-intl'
import '@formatjs/intl-relativetimeformat/polyfill'
import '@formatjs/intl-relativetimeformat/locale-data/en'
import '@formatjs/intl-relativetimeformat/locale-data/de'
import '@formatjs/intl-relativetimeformat/locale-data/es'
import '@formatjs/intl-relativetimeformat/locale-data/fr'
import '@formatjs/intl-relativetimeformat/locale-data/ja'
import '@formatjs/intl-relativetimeformat/locale-data/zh'
import enMessages from './messages/en.json'
import daMessages from './messages/fa.json'
import {WithChildren} from '../helpers'

const allMessages = {
  en: enMessages,
  fa: daMessages,
}

const I18nProvider: FC<WithChildren> = ({children}) => {
  const locale = useLang()
  const messages = allMessages[locale]
  useEffect(() => {
    document.documentElement.lang = locale
    document.documentElement.dir = ['fa', 'fa-AF', 'ar', 'prs', 'ps', 'ur'].includes(locale)
      ? 'rtl'
      : 'ltr'
  }, [locale])

  return (
    <IntlProvider locale={locale} messages={messages}>
      {children}
    </IntlProvider>
  )
}

export {I18nProvider}
